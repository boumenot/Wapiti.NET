using System;
using FluentAssertions;

namespace Wapiti.Test
{
    public static class Extensions
    {
        public static void AssertDefaults(this Opt testSubject)
        {
            testSubject.Input.Should().BeNull();
            testSubject.Output.Should().BeNull();

            testSubject.MaxEnt.Should().BeFalse();

            testSubject.Pattern.Should().BeNull();
            testSubject.Model.Should().BeNull();
            testSubject.Devel.Should().BeNull();

            testSubject.RState.Should().BeNull();
            testSubject.SState.Should().BeNull();
            testSubject.Compact.Should().BeFalse();
            testSubject.Sparse.Should().BeFalse();
            testSubject.NThread.Should().Be(1);
            testSubject.JobSize.Should().Be(64);
            testSubject.MaxIter.Should().Be(0);

            testSubject.Rho1.Should().Be(0.5);
            testSubject.Rho2.Should().Be(0.0001);

            testSubject.ObjWin.Should().Be(5);
            testSubject.StopWin.Should().Be(5);
            testSubject.StopEps.Should().Be(0.02);

            testSubject.Clip.Should().BeFalse();
            testSubject.HistSz.Should().Be(5);
            testSubject.MaxLs.Should().Be(40);

            testSubject.Eta0.Should().Be(0.8);
            testSubject.Alpha.Should().Be(0.85);

            testSubject.Kappa.Should().Be(1.5);
            testSubject.StpMin.Should().Be(1e-8);
            testSubject.StpMax.Should().Be(50.0);
            testSubject.StpInc.Should().Be(1.2);
            testSubject.StpDec.Should().Be(0.5);
            testSubject.CutOff.Should().BeFalse();

            testSubject.Label.Should().BeFalse();
            testSubject.Check.Should().BeFalse();
            testSubject.OutSc.Should().BeFalse();
            testSubject.LblPost.Should().BeFalse();
            testSubject.NBest.Should().Be(1);
            testSubject.Force.Should().BeFalse();
            testSubject.Prec.Should().Be(5);
            testSubject.All.Should().BeFalse();
        }

        public static void AssertDefaultTrains(this Opt testSubject, TrainType trainType, TrainAlgo trainAlgo)
        {
            AssertDefaults(testSubject);
            testSubject.Mode.Should().Be((int)OptMode.Train);

            testSubject.Type.Should().Be(trainType.ToString());
            testSubject.Algo.Should().Be(trainAlgo.ToString());
        }
    }
}
