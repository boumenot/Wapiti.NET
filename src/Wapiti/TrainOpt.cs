namespace Wapiti
{
    public class TrainOpt
    {
        internal Opt opt = Defaults.Opt;

        internal TrainOpt(TrainType trainType, TrainAlgo trainAlgo)
        {
            this.opt.Mode = (int)OptMode.Train;
            this.opt.Type = trainType.ToString();
            this.opt.Algo = trainAlgo.ToString();
        }

        public Opt Get()
        {
            return this.opt;
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
    
    // ==== l-bfgs
    //| --clip(l-bfgs) clip gradient
    //| --histsz INT(l-bfgs) history size
    //| --maxls INT(l-bfgs) max linesearch iters

    // ===== sgd-l1
    //| --eta0 FLOAT(sgd-l1) learning rate
    //| --alpha FLOAT(sgd-l1) exp decay parameter

    // ===== bcd
    //| --kappa FLOAT(bcd)    stability parameter

    //===== rprop
    //| --stpmin FLOAT(rprop)  minimum step size
    //| --stpmax FLOAT(rprop)  maximum step size
    //| --stpinc FLOAT(rprop)  step increment factor
    //| --stpdec FLOAT(rprop)  step decrement factor
    //| --cutoff(rprop)  alternate projection
}
