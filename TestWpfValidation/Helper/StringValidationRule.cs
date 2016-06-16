using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;


namespace TestWpfValidation.Helper
{
    public class StringValidationRule: ValidationRule
    {
        #region  Properties & Indexers
        public int MaxLength { get; set; } = int.MaxValue;
        public int MinLength { get; set; } = 0;
        public bool Nullable { get; set; } = true;
        public string RegexMatch { get; set; } = null;
        #endregion


        #region Override
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var strValue = value as string;
            if (strValue != null)
            {
                if (strValue.Length < MinLength || strValue.Length > MaxLength)
                    return new ValidationResult(false, $"Value length must be between {MinLength} and {MaxLength}.");
                if (!string.IsNullOrEmpty(RegexMatch) && !Regex.IsMatch(strValue, RegexMatch))
                    return new ValidationResult(false, $"Value is not match {RegexMatch}.");
            }
            else
            {
                if (!Nullable)
                    return new ValidationResult(false, "Value is null.");
            }
            return new ValidationResult(true, null);
        }
        #endregion
    }
}