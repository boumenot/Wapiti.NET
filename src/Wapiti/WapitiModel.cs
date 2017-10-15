using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Wapiti
{
    public class WapitiModel : IDisposable
    {
        internal WapitiModel(IntPtr model)
        {
            this.Model = model;
        }

        internal IntPtr Model { get; private set; }

        public string Label(string path)
        {
            using (var stream = File.OpenRead(path))
            {
                return this.Label(stream);
            }
        }

        public string Label(Stream stream)
        {
            var lines = new StreamReader(stream).ReadAllLines();
            return this.Label(lines);
        }

        public string Label(string[] lines)
        {
            int i = 0;
            WapitiNative.gets_cb gets_cb = () => i >= lines.Length ? null : lines[i++];

            var sb = new StringBuilder();
            WapitiNative.write_cb write_cb = (ptr, length) =>
            {
                byte[] strbuf = new byte[length];
                Marshal.Copy(ptr, strbuf, 0, length);
                var data = Encoding.UTF8.GetString(strbuf);

                WapitiNative.xfree(ptr);
                sb.Append(data);
            };

            var iol = WapitiNative.iol_new_interop(gets_cb, write_cb);
            WapitiNative.tag_label(this.Model, iol);
            WapitiNative.iol_free_interop(iol);

            return sb.ToString();
        }

        public void Dispose()
        {
            if (this.Model != IntPtr.Zero)
            {
                WapitiNative.mdl_free(this.Model);
                this.Model = IntPtr.Zero;
            }
        }
    }
}
