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
            // Support for NCrunch
            Wapiti.SetPathForNativeDllResolution(assemblyPath, "..", "lib", "native", "x64");
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

        public static WapitiModel Load(string path)
        {
            using (var stream = File.OpenRead(path))
            {
                return Wapiti.Load(stream);
            }
        }

        public static WapitiModel Load(Stream stream)
        {
            var lines = new StreamReader(stream).ReadAllLines();
            return Wapiti.Load(lines);
        }

        public static WapitiModel Load(string[] lines)
        {
            int i = 0;
            WapitiNative.gets_cb gets_cb = () => i >= lines.Length ? null : lines[i++];

            var iol = WapitiNative.iol_new_interop(gets_cb, null);
            var rdr = WapitiNative.rdr_new(iol, true);
            var mdl = WapitiNative.mdl_new(rdr);

            WapitiNative.mdl_load(mdl);
            return new WapitiModel(mdl);
        }
    }
}
