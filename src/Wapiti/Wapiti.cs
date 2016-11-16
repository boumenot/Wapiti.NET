using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace Wapiti
{
    public class Wapiti
    {
        private const string DllName = "libwapiti.dll";

        static Wapiti()
        {
            Wapiti.SetPathForNativeDllResolution();
        }

        private static string GetExecutingAssemblyPath()
        {
            var assemblyFullName = new Uri(Assembly.GetExecutingAssembly().EscapedCodeBase).LocalPath;
            var assemblyPath = Path.GetDirectoryName(assemblyFullName);

            return assemblyPath;
        }

        private static void SetPathForNativeDllResolution()
        {
            if (IntPtr.Size != 8)
            {
                const string message = "Wapiti.NET only supports 64-bit processes!";
                throw new ArgumentOutOfRangeException(message);
            }

            var assemblyPath = Wapiti.GetExecutingAssemblyPath();
            Wapiti.SetPathForNativeDllResolution(assemblyPath, "native", "x64");
            // Support for LINQPad
            Wapiti.SetPathForNativeDllResolution(assemblyPath, "..", "..", "native", "x64");
        }

        private static void SetPathForNativeDllResolution(params string[] path)
        {
            const string PATH = "PATH";
            var nativeDllPath = Path.Combine(path);

            if (!File.Exists(Path.Combine(nativeDllPath, Wapiti.DllName)))
            {
                return;
            }

            var envPath = Environment.GetEnvironmentVariable(PATH);
            if (envPath.IndexOf(nativeDllPath, StringComparison.OrdinalIgnoreCase) < 0)
            {
                var newPath = $"{nativeDllPath};{envPath}";
                Environment.SetEnvironmentVariable(PATH, newPath);
            }
        }

        private Wapiti() {}

        public string Label(WapitiModel model, string path)
        {
            using (var stream = File.OpenRead(path))
            {
                return this.Label(model, stream);
            }
        }

        public string Label(WapitiModel model, Stream stream)
        {
            var lines = new StreamReader(stream).ReadAllLines();
            return this.Label(model, lines);
        }

        public string Label(WapitiModel model, string[] lines)
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

            var iol = WapitiNative.iol_new3(gets_cb, write_cb);
            WapitiNative.tag_label(model.Model, iol);
            WapitiNative.iol_free(iol);

            return sb.ToString();
        }

        public static Wapiti Create()
        {
            return new Wapiti();
        }
    }
}
