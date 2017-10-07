namespace Wapiti
{
    public sealed class TrainResilientPropagationOptimizerOpt : TrainOpt
    {

        private TrainResilientPropagationOptimizerOpt(TrainType trainType, TrainAlgo trainAlgo)
            : base(trainType, trainAlgo)
        {
        }

        public TrainResilientPropagationOptimizerOpt SetMinimumStepSize(double stpMin)
        {
            this.opt.StpMin = stpMin;
            return this;
        }

        public TrainResilientPropagationOptimizerOpt SetMaximumStepSize(double stpMax)
        {
            this.opt.StpMax = stpMax;
            return this;
        }

        public TrainResilientPropagationOptimizerOpt StepIncrementFactor(double stpInc)
        {
            this.opt.StpInc = stpInc;
            return this;
        }

        public TrainResilientPropagationOptimizerOpt SetDecrementFactor(double stpDec)
        {
            this.opt.StpDec = stpDec;
            return this;
        }

        public static TrainResilientPropagationOptimizerOpt Train(TrainType trainType = TrainType.ConditionalRandomFields)
        {
            return new TrainResilientPropagationOptimizerOpt(trainType, TrainAlgo.ResilientPropagationOptimizer);
        }

        public static TrainResilientPropagationOptimizerOpt TrainPositive(TrainType trainType = TrainType.ConditionalRandomFields)
        {
            return new TrainResilientPropagationOptimizerOpt(trainType, TrainAlgo.ResilientPropagationOptimizerPositive);
        }

        public static TrainResilientPropagationOptimizerOpt TrainNegative(TrainType trainType = TrainType.ConditionalRandomFields)
        {
            return new TrainResilientPropagationOptimizerOpt(trainType, TrainAlgo.ResilientPropagationOptimizerNegative);
        }

    }
}