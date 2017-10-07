using FluentAssertions;
using Xunit;

namespace Wapiti.Test
{
    public partial class TrainOptTest
    {
        [Fact]
        public void ResilientPropagationOptimizerDefaults()
        {
            var testSubject = TrainResilientPropagationOptimizerOpt.Train().Get();
            testSubject.AssertDefaultTrains(TrainType.ConditionalRandomFields, TrainAlgo.ResilientPropagationOptimizer);
        }

        [Fact]
        public void ResilientPropagationOptimizerCrf()
        {
            var testSubject = TrainResilientPropagationOptimizerOpt.Train().Get();
            testSubject.AssertDefaultTrains(TrainType.ConditionalRandomFields, TrainAlgo.ResilientPropagationOptimizer);
        }

        [Fact]
        public void ResilientPropagationOptimizerMem()
        {
            var testSubject = TrainResilientPropagationOptimizerOpt.Train(TrainType.MaximumEntropyModel).Get();
            testSubject.AssertDefaultTrains(TrainType.MaximumEntropyModel, TrainAlgo.ResilientPropagationOptimizer);
        }

        [Fact]
        public void ResilientPropagationOptimizerMemm()
        {
            var testSubject = TrainResilientPropagationOptimizerOpt.Train(TrainType.MaximumEntropyMarkovModel).Get();
            testSubject.AssertDefaultTrains(TrainType.MaximumEntropyMarkovModel, TrainAlgo.ResilientPropagationOptimizer);
        }

        [Fact]
        public void ResilientPropagationOptimizerOverrides()
        {
            var testSubject = TrainResilientPropagationOptimizerOpt.Train()
                .SetMinimumStepSize(1.01)
                .SetMaximumStepSize(2.02)
                .StepIncrementFactor(3.03)
                .SetDecrementFactor(4.04)
                .Get();

            testSubject.StpMin.Should().Be(1.01);
            testSubject.StpMax.Should().Be(2.02);
            testSubject.StpInc.Should().Be(3.03);
            testSubject.StpDec.Should().Be(4.04);
        }
    }
}
