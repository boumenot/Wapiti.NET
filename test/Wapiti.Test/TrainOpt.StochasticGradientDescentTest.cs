using FluentAssertions;
using Xunit;

namespace Wapiti.Test
{
    public partial class TrainOptTest
    {
        [Fact]
        public void StochasticGradientDescentDefaults()
        {
            var testSubject = TrainStochasticGradientDescentOpt.Train().Get();
            testSubject.AssertDefaultTrains(TrainType.ConditionalRandomFields, TrainAlgo.StochasticGradientDescent);
        }

        [Fact]
        public void StochasticGradientDescentCrf()
        {
            var testSubject = TrainStochasticGradientDescentOpt.Train(TrainType.ConditionalRandomFields).Get();
            testSubject.AssertDefaultTrains(TrainType.ConditionalRandomFields, TrainAlgo.StochasticGradientDescent);
        }

        [Fact]
        public void StochasticGradientDescentMem()
        {
            var testSubject = TrainStochasticGradientDescentOpt.Train(TrainType.MaximumEntropyModel).Get();
            testSubject.AssertDefaultTrains(TrainType.MaximumEntropyModel, TrainAlgo.StochasticGradientDescent);
        }

        [Fact]
        public void StochasticGradientDescentMemm()
        {
            var testSubject = TrainStochasticGradientDescentOpt.Train(TrainType.MaximumEntropyMarkovModel).Get();
            testSubject.AssertDefaultTrains(TrainType.MaximumEntropyMarkovModel, TrainAlgo.StochasticGradientDescent);
        }

        [Fact]
        public void StochasticGradientDescentOverrides()
        {
            var testSubject = TrainStochasticGradientDescentOpt.Train(TrainType.MaximumEntropyModel)
                .SetLearningRate(1.01)
                .SetExponentialDecay(2.02)
                .Get();

            testSubject.Eta0.Should().Be(1.01);
            testSubject.Alpha.Should().Be(2.02);
        }
    }
}
