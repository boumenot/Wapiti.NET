using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace Wapiti
{
    public static class Extensions
    {
        public static string GetDescription<T>(this T e)
            where T : struct
        {
            return typeof(T).GetMember(e.ToString())[0]
                .GetCustomAttributes(typeof(DescriptionAttribute), false)
                .OfType<DescriptionAttribute>()
                .First()
                .Description;
        }

        public static string[] ReadAllLines(this TextReader reader)
        {
            return Extensions.ReadAllLinesImpl(reader).ToArray();
        }

        public static string[] ToLines(this Stream s)
        {
            var lines = new List<string>();
            using (var reader = new StreamReader(s))
            {
                while (true)
                {
                    var line = reader.ReadLine();
                    if (line == null)
                    {
                        return lines.ToArray();
                    }

                    lines.Add(line);
                }
            }
        }

        private static IEnumerable<string> ReadAllLinesImpl(TextReader reader)
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                yield return line;
            }
        }
    }
}
