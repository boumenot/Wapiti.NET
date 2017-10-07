namespace Wapiti
{
    public sealed class TrainLimitedMemoryBfgsOpt : TrainOpt
    {

        private TrainLimitedMemoryBfgsOpt(TrainType trainType)
            : base(trainType, TrainAlgo.LimitedMemoryBfgs)
        {
            //if (trainAlgo == TrainAlgo.BlockwiseCoordinatesDescent && trainType == TrainType.MaximumEntropyModel)
            //{
            //    throw new ArgumentException("Blockwise Coordinates Descent is not supported for training with Maximum Entropy Model.");
            //}

            //if (trainAlgo == TrainAlgo.BlockwiseCoordinatesDescent && trainType == TrainType.MaximumEntropyMarkovModel)
            //{
            //    throw new ArgumentException("Blockwise Coordinates Descent is not supported for training with Maximum Entropy Markov Model.");
            //}
        }

        public TrainLimitedMemoryBfgsOpt SetClipGradient()
        {
            this.opt.Clip = true;
            return this;
        }

        public TrainLimitedMemoryBfgsOpt SetHistorySize(uint count)
        {
            this.opt.HistSz = count;
            return this;
        }

        public TrainLimitedMemoryBfgsOpt MaxLinearSearchIterations(uint count)
        {
            this.opt.MaxLs = count;
            return this;
        }

        public static TrainLimitedMemoryBfgsOpt Train(TrainType trainType = TrainType.ConditionalRandomFields)
        {
            return new TrainLimitedMemoryBfgsOpt(trainType);
        }
    }
}