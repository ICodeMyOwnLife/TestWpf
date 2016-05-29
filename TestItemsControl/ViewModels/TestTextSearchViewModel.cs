using System.Collections.ObjectModel;
using System.Windows.Data;
using CB.Model.Common;
using TestItemsControl.Models;


namespace TestItemsControl.ViewModels
{
    public class TestTextSearchViewModel: ViewModelBase
    {
        #region Fields
        private int? _personAgeFilter;
        private string _personNameFilter;
        #endregion


        #region  Constructors & Destructor
        public TestTextSearchViewModel()
        {
            People = new ObservableCollection<Person>(new[]
            {
                new Person { Name = "Peter", Age = 10 },
                new Person { Name = "Jack", Age = 8 },
                new Person { Name = "David", Age = 16 },
                new Person { Name = "Henry", Age = 14 },
                new Person { Name = "George", Age = 12 },
                new Person { Name = "John", Age = 5 },
                new Person { Name = "Paul", Age = 8 },
                new Person { Name = "Hugo", Age = 13 },
                new Person { Name = "Josh", Age = 4 },
                new Person { Name = "Jennifer", Age = 17 },
                new Person { Name = "Mary", Age = 14 },
                new Person { Name = "Sarah", Age = 12 },
                new Person { Name = "Daisy", Age = 9 },
                new Person { Name = "Jim", Age = 7 },
                new Person { Name = "Jame", Age = 12 },
                new Person { Name = "Bill", Age = 10 },
                new Person { Name = "Bob", Age = 6 }
            });
            PeopleView = new ListCollectionView(People)
            {
                Filter = o => string.IsNullOrEmpty(PersonNameFilter) || ((Person)o).Name.Equals(PersonNameFilter)
            };
        }
        #endregion


        #region  Properties & Indexers
        public ObservableCollection<Person> People { get; }

        public ListCollectionView PeopleView { get; }

        public int? PersonAgeFilter
        {
            get { return _personAgeFilter; }
            set
            {
                if (SetProperty(ref _personAgeFilter, value))
                {
                    SetPeopleFilter();
                }
            }
        }

        public string PersonNameFilter
        {
            get { return _personNameFilter; }
            set
            {
                if (SetProperty(ref _personNameFilter, value))
                {
                    SetPeopleFilter();
                }
            }
        }
        #endregion


        #region Implementation
        private void SetPeopleFilter()
        {
            PeopleView.Filter = o =>
            {
                var p = (Person)o;
                return (string.IsNullOrEmpty(PersonNameFilter) || p.Name.Contains(PersonNameFilter)) &&
                       (!PersonAgeFilter.HasValue || p.Age.Equals(PersonAgeFilter.Value));
            };
        }
        #endregion
    }
}