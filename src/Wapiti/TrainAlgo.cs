using System.ComponentModel;

namespace Wapiti
{
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
}