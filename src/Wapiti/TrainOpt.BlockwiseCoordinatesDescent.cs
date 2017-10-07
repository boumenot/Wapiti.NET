namespace Wapiti
{
    public sealed class TrainBlockwiseCoordinatesDescentOpt : TrainOpt
    {
        private TrainBlockwiseCoordinatesDescentOpt(TrainType trainType)
            : base(trainType, TrainAlgo.StochasticGradientDescent)
        {
        }

        public TrainBlockwiseCoordinatesDescentOpt SetStability(double kappa)
        {
            this.opt.Kappa = kappa;
            return this;
        }

        public static TrainBlockwiseCoordinatesDescentOpt Train()
        {
            return new TrainBlockwiseCoordinatesDescentOpt(TrainType.ConditionalRandomFields);       
        }
    }
}