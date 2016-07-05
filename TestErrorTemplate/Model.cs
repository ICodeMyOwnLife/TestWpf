using System.ComponentModel.DataAnnotations;
using CB.Model.Prism;


namespace TestErrorTemplate
{
    public class Model: PrismModelBase
    {
        #region Fields
        private int _number;
        private string _text;
        #endregion


        #region  Properties & Indexers
        [Range(100, 200, ErrorMessage = "Range from 100 to 200")]
        public int Number
        {
            get { return _number; }
            set { SetProperty(ref _number, value); }
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Required")]
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }
        #endregion
    }
}