using FluentAssertions;
using Xunit;

namespace Wapiti.Test
{
    public partial class TrainOptTest
    {
        [Fact]
        public void CommonOverrides()
        {
            var testSubject = TrainLimitedMemoryBfgsOpt.Train()
                .SetL1Penalty(1.01)
                .SetL2Penalty(2.02)
                .SetCompact()
                .SetSparse()
                .SetConvergenceWindowSize(303)
                .SetStopWindowSize(404)
                .SetStopEpsilon(5.05)
                .Get();

            testSubject.Rho1.Should().Be(1.01);
            testSubject.Rho2.Should().Be(2.02);
            testSubject.Compact.Should().BeTrue();
            testSubject.Sparse.Should().BeTrue();
            testSubject.ObjWin.Should().Be(303);
            testSubject.StopWin.Should().Be(404);
            testSubject.StopEps.Should().Be(5.05);
        }
    }
}
