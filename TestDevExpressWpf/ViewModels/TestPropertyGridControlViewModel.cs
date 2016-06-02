using CB.Model.Prism;
using TestDevExpressWpf.Models;


namespace TestDevExpressWpf.ViewModels
{
    public class TestPropertyGridControlViewModel: PrismViewModelBase
    {
        #region Fields
        private TestPropertyGridControlModel _testModel = new TestPropertyGridControlModel();
        #endregion


        #region  Properties & Indexers
        public TestPropertyGridControlModel TestModel
        {
            get { return _testModel; }
            set { SetProperty(ref _testModel, value); }
        }
        #endregion
    }
}