using FluentAssertions;
using Xunit;

namespace Wapiti.Test
{
    public partial class TrainOptTest
    {
        [Fact]
        public void LimitedMemoryBgfsDefaults()
        {
            var testSubject = TrainLimitedMemoryBfgsOpt.Train().Get();
            testSubject.AssertDefaultTrains(TrainType.ConditionalRandomFields, TrainAlgo.LimitedMemoryBfgs);
        }

        [Fact]
        public void LimitedMemoryBgfsCrf()
        {
            var testSubject = TrainLimitedMemoryBfgsOpt.Train(TrainType.ConditionalRandomFields).Get();
            testSubject.AssertDefaultTrains(TrainType.ConditionalRandomFields, TrainAlgo.LimitedMemoryBfgs);
        }

        [Fact]
        public void LimitedMemoryBgfsMem()
        {
            var testSubject = TrainLimitedMemoryBfgsOpt.Train(TrainType.MaximumEntropyModel).Get();
            testSubject.AssertDefaultTrains(TrainType.MaximumEntropyModel, TrainAlgo.LimitedMemoryBfgs);
        }

        [Fact]
        public void LimitedMemoryBgfsMemm()
        {
            var testSubject = TrainLimitedMemoryBfgsOpt.Train(TrainType.MaximumEntropyMarkovModel).Get();
            testSubject.AssertDefaultTrains(TrainType.MaximumEntropyMarkovModel, TrainAlgo.LimitedMemoryBfgs);
        }

        [Fact]
        public void LimitedMemoryBgfsOverrides()
        {
            var testSubject = TrainLimitedMemoryBfgsOpt.Train(TrainType.MaximumEntropyModel)
                .SetClipGradient()
                .SetHistorySize(101)
                .MaxLinearSearchIterations(202)
                .Get();

            testSubject.Clip.Should().BeTrue();
            testSubject.HistSz.Should().Be(101);
            testSubject.MaxLs.Should().Be(202);
        }
    }
}
