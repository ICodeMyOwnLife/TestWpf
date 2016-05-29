using CB.Model.Common;


namespace TestItemsControl.Models
{
    public class Person: BindableObject
    {
        #region Fields
        private int _age;
        private string _name;
        #endregion


        #region  Properties & Indexers
        public int Age
        {
            get { return _age; }
            set { SetProperty(ref _age, value); }
        }

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
        #endregion
    }
}