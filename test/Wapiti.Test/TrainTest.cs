using ApprovalTests;
using ApprovalTests.Reporters;
using Xunit;

namespace Wapiti.Test
{
    [UseReporter(typeof(DiffReporter))]
    public class TrainTest
    {
        [Fact]
        public void GrobidDateModelTest()
        {
            var opt = TrainLimitedMemoryBfgsOpt.Train()
                .SetStopEpsilon(1e-5)
                .SetStopWindowSize(20)
                .SetMaxIterations(2000)
                .Get();

            var trainer = new WapitiTrainer();
            var result = trainer.Train(
                opt,
                "date.training.txt".GetResourceStream(),
                "date.template.txt".GetResourceStream());

            Approvals.Verify(result);
        }
    }
}
