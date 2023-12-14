using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DBConnection.Models
{
    public class RegistrationPageData : INotifyPropertyChanged
    {
        private string login;
        private string password;
        private string passwordConfirm;
        public RegistrationPageData()
        {
            RegisrationLogin = "";
            RegisrationPass = "";
            RegistrationPassConfirm = "";
        }
        public string RegisrationLogin
        {
            get => login;
            set
            {
                login = value;
                NotifyPropertyChanged();
            }
        }
        public string RegisrationPass
        {
            get => password;
            set
            {
                password = value;
                NotifyPropertyChanged();
            }
        }

        public string RegistrationPassConfirm
        {
            get => passwordConfirm;
            set
            {
                passwordConfirm = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
