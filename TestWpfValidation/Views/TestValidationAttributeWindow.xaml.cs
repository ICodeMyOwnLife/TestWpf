using System.Windows.Controls;


namespace TestWpfValidation.Views
{
    public partial class TestValidationAttributeWindow
    {
        #region  Constructors & Destructor
        public TestValidationAttributeWindow()
        {
            InitializeComponent();
        }
        #endregion


        private void Validation_OnError(object sender, ValidationErrorEventArgs e)
        {
            
        }
    }
}