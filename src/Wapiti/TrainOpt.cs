namespace Wapiti
{
    public class TrainOpt
    {
        internal Opt opt = Defaults.Opt;

        internal TrainOpt(TrainType trainType, TrainAlgo trainAlgo)
        {
            this.opt.Mode = (int)OptMode.Train;
            this.opt.Type = trainType.GetDescription();
            this.opt.Algo = trainAlgo.GetDescription();
        }

        public TrainOpt SetL1Penalty(double rho1)
        {
            this.opt.Rho1 = rho1;
            return this;
        }

        public TrainOpt SetL2Penalty(double rho2)
        {
            this.opt.Rho2 = rho2;
            return this;
        }

        public TrainOpt SetCompact()
        {
            this.opt.Compact = true;
            return this;
        }

        public TrainOpt SetSparse()
        {
            this.opt.Sparse = true;
            return this;
        }

        public TrainOpt SetConvergenceWindowSize(uint objwin)
        {
            this.opt.ObjWin = objwin;
            return this;
        }

        public TrainOpt SetStopWindowSize(uint stopwin)
        {
            this.opt.StopWin = stopwin;
            return this;
        }

        public TrainOpt SetStopEpsilon(double stopeps)
        {
            this.opt.StopEps = stopeps;
            return this;
        }

        public TrainOpt SetMaxIterations(uint maxiter)
        {
            this.opt.MaxIter = maxiter;
            return this;
        }

        public Opt Get()
        {
            return this.opt;
        }
    }
}
