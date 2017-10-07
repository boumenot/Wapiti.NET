using FluentAssertions;
using Xunit;

namespace Wapiti.Test
{
    public partial class TrainOptTest
    {
        [Fact]
        public void ResilientPropagationOptimizerPositiveDefaults()
        {
            var testSubject = TrainResilientPropagationOptimizerOpt.TrainPositive().Get();
            testSubject.AssertDefaultTrains(TrainType.ConditionalRandomFields, TrainAlgo.ResilientPropagationOptimizerPositive);
        }

        [Fact]
        public void ResilientPropagationOptimizerPositiveCrf()
        {
            var testSubject = TrainResilientPropagationOptimizerOpt.TrainPositive().Get();
            testSubject.AssertDefaultTrains(TrainType.ConditionalRandomFields, TrainAlgo.ResilientPropagationOptimizerPositive);
        }

        [Fact]
        public void ResilientPropagationOptimizerPositiveMem()
        {
            var testSubject = TrainResilientPropagationOptimizerOpt.TrainPositive(TrainType.MaximumEntropyModel).Get();
            testSubject.AssertDefaultTrains(TrainType.MaximumEntropyModel, TrainAlgo.ResilientPropagationOptimizerPositive);
        }

        [Fact]
        public void ResilientPropagationOptimizerPositiveMemm()
        {
            var testSubject = TrainResilientPropagationOptimizerOpt.TrainPositive(TrainType.MaximumEntropyMarkovModel).Get();
            testSubject.AssertDefaultTrains(TrainType.MaximumEntropyMarkovModel, TrainAlgo.ResilientPropagationOptimizerPositive);
        }

        [Fact]
        public void ResilientPropagationOptimizerPositiveOverrides()
        {
            var testSubject = TrainResilientPropagationOptimizerOpt.TrainPositive()
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
