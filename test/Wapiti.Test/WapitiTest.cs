using ApprovalTests;
using ApprovalTests.Reporters;

using Xunit;

namespace Wapiti.Test
{
    [UseReporter(typeof(DiffReporter))]
    public class WapitiTest
    {
        [Fact]
        public void GrobidModelDate00()
        {
            // 10 January 2001
            var lines = new[]
            {
                "10 10 1 10 10 10 0 10 10 10 LINESTART NOCAPS ALLDIGIT 0 0 0 NOPUNCT <date>",
                "January january J Ja Jan Janu y ry ary uary LINEIN INITCAP NODIGIT 0 0 1 NOPUNCT <date>",
                "2001 2001 2 20 200 2001 1 01 001 2001 LINEEND NOCAPS ALLDIGIT 0 1 0 NOPUNCT <date>",
            };

            this.ApproveModel(lines, "date.model.wapiti");
        }

        [Fact]
        public void GrobidModelDate01()
        {
            // 15-08-2007
            var lines = new[]
            {
                "15 15 1 15 15 15 5 15 15 15 LINESTART NOCAPS ALLDIGIT 0 0 0 NOPUNCT <date>",
                "- - - - - - - - - - LINEIN ALLCAP NODIGIT 1 0 0 HYPHEN <date>",
                "08 08 0 08 08 08 8 08 08 08 LINEIN NOCAPS ALLDIGIT 0 0 0 NOPUNCT <date>",
                "- - - - - - - - - - LINEIN ALLCAP NODIGIT 1 0 0 HYPHEN <date>",
                "2007 2007 2 20 200 2007 7 07 007 2007 LINEEND NOCAPS ALLDIGIT 0 1 0 NOPUNCT <date>",
            };

            this.ApproveModel(lines, "date.model.wapiti");
        }

        [Fact]
        public void GrobidModelDate02()
        {
            // November 14 1999
            var lines = new[]
            {
                "November november N No Nov Nove r er ber mber LINESTART INITCAP NODIGIT 0 0 1 NOPUNCT <date>",
                "14 14 1 14 14 14 4 14 14 14 LINEIN NOCAPS ALLDIGIT 0 0 0 NOPUNCT <date>",
                "1999 1999 1 19 199 1999 9 99 999 1999 LINEEND NOCAPS ALLDIGIT 0 1 0 NOPUNCT <date>",
            };

            this.ApproveModel(lines, "date.model.wapiti");
        }

        [Fact]
        public void GrobidModelDate03()
        {
            // 19 November 1 999
            var lines = new[]
            {
                "19 19 1 19 19 19 9 19 19 19 LINESTART NOCAPS ALLDIGIT 0 0 0 NOPUNCT <date>",
                "November november N No Nov Nove r er ber mber LINEIN INITCAP NODIGIT 0 0 1 NOPUNCT <date>",
                "1 1 1 1 1 1 1 1 1 1 LINEIN NOCAPS ALLDIGIT 1 0 0 NOPUNCT <date>",
                "999 999 9 99 999 999 9 99 999 999 LINEEND NOCAPS ALLDIGIT 0 0 0 NOPUNCT <date>",
            };

            this.ApproveModel(lines, "date.model.wapiti");
        }

        private void ApproveModel(string[] lines, string path)
        {
            using (var model = WapitiModel.Load(path))
            {
                var testSubject = Wapiti.Create();
                var result = testSubject.Label(model, lines);

                Approvals.Verify(result);
            }
        }
    }
}
