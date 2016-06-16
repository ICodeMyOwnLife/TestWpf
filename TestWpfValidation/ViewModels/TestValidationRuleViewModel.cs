using CB.Model.Prism;
using TestWpfValidation.Models;


namespace TestWpfValidation.ViewModels
{
    public class TestValidationRuleViewModel: PrismViewModelBase
    {
        #region  Properties & Indexers
        public Person Person { get; } = new Person();
        #endregion
    }
}