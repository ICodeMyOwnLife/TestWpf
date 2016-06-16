using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using CB.Model.Prism;
using Microsoft.Practices.Prism.Commands;


namespace TestBinding.ViewModels
{
    public class TestObjectDataProviderViewModel: PrismViewModelBase
    {
        #region Fields
        private static readonly Random _random = new Random(DateTime.Now.Millisecond);
        private int[] _numbers;
        #endregion


        #region  Constructors & Destructor
        public TestObjectDataProviderViewModel()
        {
            LoadAsynCommand = DelegateCommand.FromAsyncHandler(LoadAsync);
            Load();
        }
        #endregion


        #region  Commands
        public ICommand LoadAsynCommand { get; }
        #endregion


        #region  Properties & Indexers
        public int[] Numbers
        {
            get { return _numbers; }
            set { SetProperty(ref _numbers, value); }
        }
        #endregion


        #region Methods
        public void Load()
            => Numbers = LoadNumbers();

        public async Task LoadAsync()
            => Numbers = await LoadNumbersAsync();

        public int[] LoadNumbers()
        {
            return Enumerable.Range(0, _random.Next(300, 320)).Select(i =>
            {
                Thread.Sleep(_random.Next(40, 60));
                return _random.Next(100, 999);
            }).ToArray();
        }

        public async Task<int[]> LoadNumbersAsync()
            => await Task.Run(() => LoadNumbers());
        #endregion
    }
}