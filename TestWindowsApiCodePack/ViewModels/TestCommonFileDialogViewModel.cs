using System.Collections.Generic;
using System.Windows.Input;
using CB.Model.Prism;
using Microsoft.WindowsAPICodePack.Dialogs;
using Prism.Commands;


namespace TestWindowsApiCodePack.ViewModels
{
    public class TestCommonFileDialogViewModel: PrismViewModelBase
    {
        #region Fields
        private IEnumerable<string> _paths;
        #endregion


        #region  Constructors & Destructor
        public TestCommonFileDialogViewModel()
        {
            OpenFilesCommand = new DelegateCommand(OpenFiles);
        }
        #endregion


        #region  Commands
        public ICommand OpenFilesCommand { get; }
        #endregion


        #region  Properties & Indexers
        public IEnumerable<string> Paths
        {
            get { return _paths; }
            private set { SetProperty(ref _paths, value); }
        }
        #endregion


        #region Methods
        public void OpenFiles()
        {
            using (var dialog = new CommonOpenFileDialog
            {
                Multiselect = true,
            })
            {
                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    Paths = dialog.FileNames;
                }
            }
        }
        #endregion
    }
}