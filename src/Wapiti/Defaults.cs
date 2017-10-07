namespace Wapiti
{
    public static class Defaults
    {
        public static readonly Opt Opt = new Opt()
        {
            Mode = -1,
            Input = null,
            Output = null,
            MaxEnt = false,

            Type = "crf",
            Algo = "l-bfgs",
            Pattern = null,
            Model = null,
            Devel = null,
            RState = null,
            SState = null,

            Compact = false,
            Sparse = false,
            NThread = 1,
            JobSize = 64,
            MaxIter = 0,
            Rho1 = 0.5,
            Rho2 = 0.0001,

            ObjWin = 5,
            StopWin = 5,
            StopEps = 0.02,

            Clip = false,
            HistSz = 5,
            MaxLs = 40,

            Eta0 = 0.8,
            Alpha = 0.85,

            Kappa = 1.5,

            StpMin = 1e-8,
            StpMax = 50.0,
            StpInc = 1.2,
            StpDec = 0.5,
            CutOff = false,

            Label = false,
            Check = false,
            OutSc = false,
            LblPost = false,
            NBest = 1,
            Force = false,

            Prec = 5,
            All = false,
        };
    }
}