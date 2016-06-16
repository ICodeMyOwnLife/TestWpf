using System.ComponentModel;
using System.Globalization;
using System.Windows.Controls;


namespace TestWpfValidation.Helper
{
    public class IntValidationRule: ValidationRule
    {
        #region  Properties & Indexers
        public int Max { get; set; } = int.MaxValue;
        public int Min { get; set; } = int.MinValue;
        #endregion


        #region Override
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int intValue;
            if (!TryGetInt(value, out intValue))
                return new ValidationResult(false, "Value is not an integer.");
            if (intValue < Min || intValue > Max)
                return new ValidationResult(false, $"Value must be between {Min} and {Max}.");
            return new ValidationResult(true, null);
        }
        #endregion


        #region Implementation
        private bool TryGetInt(object value, out int intValue)
        {
            if (value is int)
            {
                intValue = (int)value;
                return true;
            }
            var converter = new Int32Converter();
            var convertedValue = converter.ConvertFrom(value);
            if (convertedValue != null)
            {
                intValue = (int)convertedValue;
                return true;
            }
            intValue = 0;
            return false;
        }
        #endregion
    }
}