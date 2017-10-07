using FluentAssertions;
using Xunit;

namespace Wapiti.Test
{
    public partial class TrainOptTest
    {
        [Fact]
        public void BlockwiseCoordinatesDescentDefaults()
        {
            var testSubject = TrainBlockwiseCoordinatesDescentOpt.Train().Get();
            testSubject.AssertDefaultTrains(TrainType.ConditionalRandomFields, TrainAlgo.StochasticGradientDescent);
        }

        [Fact]
        public void BlockwiseCoordinatesDescentCrf()
        {
            var testSubject = TrainBlockwiseCoordinatesDescentOpt.Train().Get();
            testSubject.AssertDefaultTrains(TrainType.ConditionalRandomFields, TrainAlgo.StochasticGradientDescent);
        }

        [Fact]
        public void BlockwiseCoordinatesDescentOverrides()
        {
            var testSubject = TrainBlockwiseCoordinatesDescentOpt.Train()
                .SetStability(1.01)
                .Get();

            testSubject.Kappa.Should().Be(1.01);
        }
    }
}
