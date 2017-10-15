using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Wapiti
{
    public class WapitiTrainer
    {
        public string Train(Opt trainOpt, string[] modelLines, string[] patternLines)
        {
            int model_idx = 0;
            WapitiNative.gets_cb model_gets_cb = () => model_idx >= modelLines.Length ? null : modelLines[model_idx++];

            int pattern_idx = 0;
            WapitiNative.gets_cb pattern_gets_cb = () => pattern_idx >= patternLines.Length ? null : patternLines[pattern_idx++];

            var sb = new StringBuilder();
            WapitiNative.write_cb write_cb = (ptr, length) =>
            {
                byte[] strbuf = new byte[length];
                Marshal.Copy(ptr, strbuf, 0, length);
                var data = Encoding.UTF8.GetString(strbuf);

                WapitiNative.xfree(ptr);
                sb.Append(data);
            };

            var iol_model = WapitiNative.iol_new_interop(model_gets_cb, write_cb);
            var iol_pattern = WapitiNative.iol_new_interop(pattern_gets_cb, null);

            var optPtr = Marshal.AllocHGlobal(Marshal.SizeOf<Opt>());
            Marshal.StructureToPtr(trainOpt, optPtr, false);

            int result = WapitiNative.train(optPtr, iol_model, iol_pattern);
            if (result != 0)
            {
                throw new Exception($"training failed :: {result}");
            }

            Marshal.FreeHGlobal(optPtr);
            WapitiNative.iol_free_interop(iol_model);
            WapitiNative.iol_free_interop(iol_pattern);

            return sb.ToString();
        }

        public string Train(Opt trainOpt, Stream modelStream, Stream patternStream)
        {
            return this.Train(trainOpt, modelStream.ToLines(), patternStream.ToLines());
        }
    }
}
