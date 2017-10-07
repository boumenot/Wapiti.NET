using FluentAssertions;
using Xunit;

namespace Wapiti.Test
{
    public partial class TrainOptTest
    {
        [Fact]
        public void ResilientPropagationOptimizerNegativeDefaults()
        {
            var testSubject = TrainResilientPropagationOptimizerOpt.TrainNegative().Get();
            testSubject.AssertDefaultTrains(TrainType.ConditionalRandomFields, TrainAlgo.ResilientPropagationOptimizerNegative);
        }

        [Fact]
        public void ResilientPropagationOptimizerNegativeCrf()
        {
            var testSubject = TrainResilientPropagationOptimizerOpt.TrainNegative().Get();
            testSubject.AssertDefaultTrains(TrainType.ConditionalRandomFields, TrainAlgo.ResilientPropagationOptimizerNegative);
        }

        [Fact]
        public void ResilientPropagationOptimizerNegativeMem()
        {
            var testSubject = TrainResilientPropagationOptimizerOpt.TrainNegative(TrainType.MaximumEntropyModel).Get();
            testSubject.AssertDefaultTrains(TrainType.MaximumEntropyModel, TrainAlgo.ResilientPropagationOptimizerNegative);
        }

        [Fact]
        public void ResilientPropagationOptimizerNegativeMemm()
        {
            var testSubject = TrainResilientPropagationOptimizerOpt.TrainNegative(TrainType.MaximumEntropyMarkovModel).Get();
            testSubject.AssertDefaultTrains(TrainType.MaximumEntropyMarkovModel, TrainAlgo.ResilientPropagationOptimizerNegative);
        }

        [Fact]
        public void ResilientPropagationOptimizerNegativeOverrides()
        {
            var testSubject = TrainResilientPropagationOptimizerOpt.TrainNegative()
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
