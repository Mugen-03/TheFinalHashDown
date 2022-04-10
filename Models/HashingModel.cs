using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SimpleOneWayHashing.Models
{
    public class HashingModel
    {
        #region Private Members
        private string appTitle = "One-Way Password Hashing";
        private string result;
        #endregion

        #region Constructor
        public HashingModel(string _plainText, string _salt)
        {
            PlainText = _plainText;
            Salt = _salt;
            result = string.Empty;
        }
        public HashingModel()
        {
            PlainText = string.Empty;
            Salt = string.Empty;
            result = string.Empty;
        }
        #endregion

        #region Public Properties and Methods
        public string AppTitle { get { return appTitle; } }
        public string PlainText { get; set; }
        public string Salt { get; set; }
        public string Result { get { return result; } }

        public void ComputingResult()
        {
            UTF8Encoding utf8 = new UTF8Encoding();
            byte[] textWithSaltBytes = utf8.GetBytes(string.Concat(PlainText, Salt));
            HashAlgorithm hasher = new SHA1CryptoServiceProvider();
            byte[] hashedBytes = hasher.ComputeHash(textWithSaltBytes);
            hasher.Clear();
            result = Convert.ToBase64String(hashedBytes);
        }
        #endregion
    }
}
