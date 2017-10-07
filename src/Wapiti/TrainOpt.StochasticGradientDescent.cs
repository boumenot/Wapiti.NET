namespace Wapiti
{
    public sealed class TrainStochasticGradientDescentOpt : TrainOpt
    {
        private TrainStochasticGradientDescentOpt(TrainType trainType)
            : base(trainType, TrainAlgo.StochasticGradientDescent)
        {
        }

        public TrainStochasticGradientDescentOpt SetLearningRate(double eta0)
        {
            this.opt.Eta0 = eta0;
            return this;
        }

        public TrainStochasticGradientDescentOpt SetExponentialDecay(double alpha)
        {
            this.opt.Alpha = alpha;
            return this;
        }

        public static TrainStochasticGradientDescentOpt Train(TrainType trainType = TrainType.ConditionalRandomFields)
        {
            return new TrainStochasticGradientDescentOpt(trainType);       
        }
    }
}