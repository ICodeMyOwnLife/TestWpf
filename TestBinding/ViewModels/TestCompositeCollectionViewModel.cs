using System;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media;
using CB.Model.Prism;
using Microsoft.Practices.Prism.Commands;


namespace TestBinding.ViewModels
{
    /*public class TestCompositeCollectionViewModel: PrismViewModelBase
    {
        #region Fields
        private static readonly Random _random = new Random(DateTime.Now.Millisecond);
        private Color[] _list1 = { Colors.Red };
        private Color[] _list2 = { Colors.Green };
        private Color[] _list3 = { Colors.Blue };
        #endregion


        #region  Constructors & Destructor
        public TestCompositeCollectionViewModel()
        {
            LoadList1Command = new DelegateCommand(LoadList1);
            LoadList2Command = new DelegateCommand(LoadList2);
            LoadList3Command = new DelegateCommand(LoadList3);
        }
        #endregion


        #region  Commands
        public ICommand LoadList1Command { get; }
        public ICommand LoadList2Command { get; }
        public ICommand LoadList3Command { get; }
        #endregion


        #region  Properties & Indexers
        public Color[] List1
        {
            get { return _list1; }
            private set { SetProperty(ref _list1, value); }
        }

        public Color[] List2
        {
            get { return _list2; }
            private set { SetProperty(ref _list2, value); }
        }

        public Color[] List3
        {
            get { return _list3; }
            private set { SetProperty(ref _list3, value); }
        }
        #endregion


        #region Methods
        public void LoadList1()
            => List1 = LoadColors();

        public void LoadList2()
            => List2 = LoadColors();

        public void LoadList3()
            => List3 = LoadColors();
        #endregion


        #region Implementation
        private static Color[] LoadColors()
            => Enumerable.Range(0, _random.Next(100, 120)).Select(i =>
            {
                var bytes = new byte[3];
                _random.NextBytes(bytes);
                return Color.FromRgb(bytes[0], bytes[1], bytes[2]);
            }).ToArray();
        #endregion
    }*/

    public class TestCompositeCollectionViewModel : PrismViewModelBase
    {
        #region Fields
        private static readonly Random _random = new Random(DateTime.Now.Millisecond);
        private int[] _list1 = { 1,2,3 };
        private int[] _list2 = { 4,5,6};
        private int[] _list3 = { 7,8,9};
        #endregion


        #region  Constructors & Destructor
        public TestCompositeCollectionViewModel()
        {
            LoadList1Command = new DelegateCommand(LoadList1);
            LoadList2Command = new DelegateCommand(LoadList2);
            LoadList3Command = new DelegateCommand(LoadList3);
        }
        #endregion


        #region  Commands
        public ICommand LoadList1Command { get; }
        public ICommand LoadList2Command { get; }
        public ICommand LoadList3Command { get; }
        #endregion


        #region  Properties & Indexers
        public int[] List1
        {
            get { return _list1; }
            private set { SetProperty(ref _list1, value); }
        }

        public int[] List2
        {
            get { return _list2; }
            private set { SetProperty(ref _list2, value); }
        }

        public int[] List3
        {
            get { return _list3; }
            private set { SetProperty(ref _list3, value); }
        }
        #endregion


        #region Methods
        public void LoadList1()
            => List1 = LoadNumbers();

        public void LoadList2()
            => List2 = LoadNumbers();

        public void LoadList3()
            => List3 = LoadNumbers();
        #endregion


        #region Implementation
        private static int[] LoadNumbers()
            => Enumerable.Range(0, _random.Next(100, 120)).Select(i => _random.Next(100, 999)).ToArray();
        #endregion
    }
}