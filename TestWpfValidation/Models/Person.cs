using System.ComponentModel.DataAnnotations;
using CB.Model.Common;
using CB.Model.Prism;


namespace TestWpfValidation.Models
{
    public class Person: BindableObject
    {
        #region Fields
        private int _age;
        private string _userName;
        #endregion


        #region  Properties & Indexers
        [Required(ErrorMessage = "Age must be provided")]
        [Range(0, 100, ErrorMessage = "Age must be between 0 and 100.")]
        public int Age
        {
            get { return _age; }
            set { SetProperty(ref _age, value); }
        }

        [Required(ErrorMessage = "User name must be provided.", AllowEmptyStrings = false)]
        [StringLength(12, MinimumLength = 6, ErrorMessage = "User name must be between 6 and 12 characters-length.")]
        public string UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }
        #endregion
    }
}