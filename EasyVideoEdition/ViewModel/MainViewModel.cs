using EasyVideoEdition.Model;
using EasyVideoEdition.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EasyVideoEdition.ViewModel
{
    class MainViewModel : ObjectBase
    {
        #region Attributes

        #endregion


        #region CommandList
        /// <summary>
        /// THIS IS A TEST !
        /// </summary>
        public ICommand GoToOpenCommand
        {
            get; private set;
        }

        public ICommand GoToSaveCommand
        {
            get; private set;
        }
        #endregion

        /// <summary>
        /// Creation of the MainViewModel. Nottably, create the commands.  
        /// </summary>
        public MainViewModel()
        {
            //viewModel = new FileOpeningViewModel();
            GoToOpenCommand = new RelayCommand(GoToOpen);
            GoToSaveCommand = new RelayCommand(GoToSave);
        }

        /// <summary>
        /// 
        /// </summary>
        private void GoToOpen()
        {
            MessageBox.Show("THIS IS A FUCKING TEST");
        }

        /// <summary>
        /// 
        /// </summary>
        private void GoToSave()
        {

        }

        #region CommandDefinition

        #endregion
    }
}
