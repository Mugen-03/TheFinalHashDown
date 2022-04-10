using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SimpleOneWayHashing.Commands;
using SimpleOneWayHashing.Models;
using System.Windows.Input;

namespace SimpleOneWayHashing.ViewModels
{
    public class HashingViewModel : ViewModelBase
    {
        #region Private Members
        private Models.HashingModel hashing;

        private DelegateCommand computeHashCommand;
        private DelegateCommand clearTextBoxCommand;

        private string hashingTitle;
        private string computedHash;
        #endregion

        #region Constructor
        public HashingViewModel()
        {
            this.hashing = new HashingModel();
            hashingTitle = hashing.AppTitle;
            this.PlainText = string.Empty;
            this.Salt = string.Empty;
            this.computedHash = string.Empty;
        }
        #endregion

        #region Public Properties
        public string HashingTitle
        {
            get { return hashingTitle; }
        }
        public string PlainText
        {
            get { return hashing.PlainText; }
            set { hashing.PlainText = value; }
        }

        public string Salt
        {
            get { return hashing.Salt; }
            set { hashing.Salt = value; }
        }

        public string Result
        {
            get { return hashing.Result; }
        }

        public string ComputedHash
        {
            get { return computedHash; }
            set
            {
                computedHash = value;
                OnPropertyChanged("ComputedHash");
            }
        }
        #endregion

        #region Commands
        public ICommand ComputeHashCommand
        {
            get
            {
                if (computeHashCommand == null)
                {
                    computeHashCommand = new DelegateCommand(ComputeHash, CanComputeHash);
                }
                return computeHashCommand;
            }
        }

        private bool CanComputeHash()
        {
            if (!string.IsNullOrEmpty(this.PlainText) && !string.IsNullOrEmpty(this.Salt))
                return true;
            else
                return false;
        }

        private void ComputeHash()
        {
            hashing.ComputingResult();
            ComputedHash = Result;
        }

        public ICommand ClearTextBoxCommand
        {
            get
            {
                if (clearTextBoxCommand == null)
                {
                    clearTextBoxCommand = new DelegateCommand(ClearTextBox);
                }
                return clearTextBoxCommand;
            }
        }

        private void ClearTextBox()
        {
            this.PlainText = string.Empty;
            OnPropertyChanged("PlainText");

            this.Salt = string.Empty;
            OnPropertyChanged("Salt");
            
            this.ComputedHash = string.Empty;
        }
        #endregion
    }
}
