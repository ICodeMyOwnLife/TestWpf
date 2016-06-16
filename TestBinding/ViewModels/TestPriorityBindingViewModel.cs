using System;
using System.Threading;
using CB.Model.Prism;


namespace TestBinding.ViewModels
{
    public class TestPriorityBindingViewModel: PrismViewModelBase
    {
        #region Fields
        private static readonly Random _random = new Random(DateTime.Now.Millisecond);
        #endregion


        #region  Properties & Indexers
        public string FastTast
        {
            get
            {
                var begin = DateTime.Now;
                Thread.Sleep(_random.Next(1800, 2200));
                return $"Fast tast: {(DateTime.Now - begin).Milliseconds} ms";
            }
        }

        public string MediumTask
        {
            get
            {
                var begin = DateTime.Now;
                Thread.Sleep(_random.Next(3600, 4400));
                return $"Medium task: {(DateTime.Now - begin).Milliseconds} ms";
            }
        }

        public string SlowTask
        {
            get
            {
                var begin = DateTime.Now;
                Thread.Sleep(_random.Next(7200, 8800));
                return $"Slow tast: {(DateTime.Now - begin).Milliseconds} ms";
            }
        }
        #endregion
    }
}