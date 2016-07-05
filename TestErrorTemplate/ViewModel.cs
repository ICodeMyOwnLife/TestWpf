using System.Collections.Generic;
using CB.Model.Prism;


namespace TestErrorTemplate
{
    public class ViewModel: PrismViewModelBase
    {
        #region  Properties & Indexers
        public IList<Model> Models { get; } = new List<Model>();
        #endregion
    }
}