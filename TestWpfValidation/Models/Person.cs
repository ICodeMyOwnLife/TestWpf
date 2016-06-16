using System;
using System.ComponentModel.DataAnnotations;
using CB.Model.Prism;


namespace TestWpfValidation.Models
{
    public class Person: PrismModelBase
    {
        #region Fields
        private int _age;
        private string _name;
        private int _yearOfBirth;
        #endregion


        #region  Properties & Indexers
        [Required(ErrorMessage = "Age must be provided")]
        [Range(0, 100, ErrorMessage = "Age must be between 0 and 100.")]
        [CustomValidation(typeof(Person), nameof(ValidatePerson))]
        public int Age
        {
            get { return _age; }
            set { SetProperty(ref _age, value); }
        }

        [Required(ErrorMessage = "Name must be provided.", AllowEmptyStrings = false)]
        [StringLength(12, MinimumLength = 6, ErrorMessage = "Name must be between 6 and 12 characters-length.")]
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        [Required(ErrorMessage = "Year of birth must be provided")]
        [CustomValidation(typeof(Person), nameof(ValidatePerson))]
        public int YearOfBirth
        {
            get { return _yearOfBirth; }
            set
            {
                if (SetProperty(ref _yearOfBirth, value))
                {
                    if (YearOfBirth > DateTime.Today.Year)
                        SetError("Year of birth must be not larger than current year.");
                }
            }
        }
        #endregion


        #region Implementation
        private void CoerceBirthYear()
        {
            if (DateTime.Now.Year - YearOfBirth != Age)
            {
                var error = "Age doesn't suit year of birth";
                SetPropertyErrors(nameof(Age), error);
                SetPropertyErrors(nameof(YearOfBirth), error);
            }
        }

        public static ValidationResult ValidatePerson(Person p, ValidationContext context)
            => DateTime.Now.Year - p.YearOfBirth != p.Age ? new ValidationResult("Age doesn't suit year of birth", new[] { nameof(Age), nameof(YearOfBirth) }) : ValidationResult.Success;
        #endregion
    }
}


// TODO: test Multi-Validation, CompositeCollection, Multi-Binding