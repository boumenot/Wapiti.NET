using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wapiti
{
    public enum OptMode
    {
        Train = 0,
        Label = 1,
        Dump = 2,
        Update = 3,
    };

    public enum TrainAlgo
    {
        [Description("l-bfgs")]
        // Limited-Memory Broyden-Fletcher-Goldfarb-Shanno
        // https://en.wikipedia.org/wiki/Limited-memory_BFGS
        LimitedMemoryBfgs= 0,

        [Description("sgd-l1")]
        // https://en.wikipedia.org/wiki/Stochastic_gradient_descent
        StochasticGradientDescen = 1,

        [Description("bcd")]
        // https://en.wikipedia.org/wiki/Coordinate_descent
        BlockwiseCoordinatesDescent = 2,

        [Description("rprop")]
        // https://en.wikipedia.org/wiki/Rprop
        ResilientPropagationOptimizer = 3,

        [Description("rprop+")]
        // https://en.wikipedia.org/wiki/Rprop
        ResilientPropagationOptimizerPositive = 4,

        [Description("rprop-")]
        // https://en.wikipedia.org/wiki/Rprop
        ResilientPropagationOptimizerNegative = 5,
    }

    public enum TrainType
    {
        [Description("maxent")]
        MaximumEntropyModel = 0,

        [Description("memm")]
        // https://en.wikipedia.org/wiki/Maximum-entropy_Markov_model
        MaximumEntropyMarkovModel = 1,

        [Description("crf")]
        // https://en.wikipedia.org/wiki/Conditional_random_field
        ConditionalRandomFields = 2,
    }

    public sealed class TrainLimitedMemoryBfgsOpt
    {
        private Opt opt;

        public TrainLimitedMemoryBfgsOpt(TrainType trainType)
        {
            //if (trainAlgo == TrainAlgo.BlockwiseCoordinatesDescent && trainType == TrainType.MaximumEntropyModel)
            //{
            //    throw new ArgumentException("Blockwise Coordinates Descent is not supported for training with Maximum Entropy Model.");
            //}

            //if (trainAlgo == TrainAlgo.BlockwiseCoordinatesDescent && trainType == TrainType.MaximumEntropyMarkovModel)
            //{
            //    throw new ArgumentException("Blockwise Coordinates Descent is not supported for training with Maximum Entropy Markov Model.");
            //}

            this.opt = new Opt()
            {
                Mode = (int)OptMode.Label,
                Algo = TrainAlgo.LimitedMemoryBfgs.ToString(),
                Type = trainType.ToString(),

                Clip = false,
                HistSz = 5,
                MaxLs = 40,
            };  
        }

        public Opt Get()
        {
            return this.opt;
        }

        public TrainLimitedMemoryBfgsOpt SetClip()
        {
            this.opt.Clip = true;
            return this;
        }

        public TrainLimitedMemoryBfgsOpt SetHistSz()
        {
            this.opt.Clip = true;
            return this;
        }

        public TrainLimitedMemoryBfgsOpt MaxLs()
        {
            this.opt.Clip = true;
            return this;
        }


        public static TrainLimitedMemoryBfgsOpt Train(TrainType trainType)
        {
            return new TrainLimitedMemoryBfgsOpt(trainType);
        }
    }

    //-T | --type STRING  type of model to train
    //-a | --algo STRING  training algorithm to use
    //-p | --pattern FILE    patterns for extracting features
    //-m | --model FILE    model file to preload
    //-d | --devel FILE    development dataset
    //| --rstate FILE    optimizer state to restore
    //| --sstate FILE    optimizer state to save
    //-c | --compact compact model after training
    //-t | --nthread INT     number of worker threads
    //-j | --jobsize INT     job size for worker threads
    //-s | --sparse enable sparse forward/backward
    //-i | --maxiter INT     maximum number of iterations
    //-1 |┬á--rho1 FLOAT   l1 penalty parameter
    //-2 | --rho2 FLOAT   l2 penalty parameter
    //-o | --objwin INT     convergence window size
    //-w | --stopwin INT     stop window size
    //-e | --stopeps FLOAT   stop epsilon value
    //| --clip(l-bfgs) clip gradient
    //| --histsz INT(l-bfgs) history size
    //| --maxls INT(l-bfgs) max linesearch iters
    //| --eta0 FLOAT(sgd-l1) learning rate
    //| --alpha FLOAT(sgd-l1) exp decay parameter
    //| --kappa FLOAT(bcd)    stability parameter
    //| --stpmin FLOAT(rprop)  minimum step size
    //| --stpmax FLOAT(rprop)  maximum step size
    //| --stpinc FLOAT(rprop)  step increment factor
    //| --stpdec FLOAT(rprop)  step decrement factor
    //| --cutoff(rprop)  alternate projection
}
