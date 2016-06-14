using System;
using System.Collections.ObjectModel;
using System.Windows.Data;
using CB.Model.Prism;
using TestWpfValidation.Models;


namespace TestWpfValidation.ViewModels
{
    public class TestValidationAttributeViewModel: PrismViewModelBase
    {
        #region Fields
        private Person _selectedPerson;
        #endregion


        #region  Constructors & Destructor
        public TestValidationAttributeViewModel()
        {
            People = new ObservableCollection<Person>();
            PeopleView = new ListCollectionView(People);
            PeopleView.CurrentChanged += PeopleView_CurrentChanged;
        }
        #endregion


        #region  Properties & Indexers
        public ObservableCollection<Person> People { get; }

        public ListCollectionView PeopleView { get; }

        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set { SetProperty(ref _selectedPerson, value); }
        }
        #endregion


        #region Event Handlers
        private void PeopleView_CurrentChanged(object sender, EventArgs e)
        {
            SelectedPerson = (Person)PeopleView.CurrentItem;
        }
        #endregion
    }
}