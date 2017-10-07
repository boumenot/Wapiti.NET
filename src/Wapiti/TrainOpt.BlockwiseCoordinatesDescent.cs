namespace Wapiti
{
    public sealed class TrainBlockwiseCoordinatesDescentOpt : TrainOpt
    {
        private TrainBlockwiseCoordinatesDescentOpt(TrainType trainType)
            : base(trainType, TrainAlgo.BlockwiseCoordinatesDescent)
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