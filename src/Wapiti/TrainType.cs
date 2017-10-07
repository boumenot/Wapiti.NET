using System.ComponentModel;

namespace Wapiti
{
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
}