using FluentAssertions;
using Xunit;

namespace Wapiti.Test
{
    public class OptTest
    {
        [Fact]
        public void AssertDefaultValues()
        {
            var testSubject = Defaults.Opt;

            testSubject.AssertDefaults();

            testSubject.Mode.Should().Be(-1);
            testSubject.Type.Should().Be("crf");
            testSubject.Algo.Should().Be("l-bfgs");
        }
    };
}
