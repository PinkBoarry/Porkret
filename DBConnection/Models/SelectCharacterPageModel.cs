using DBConnection.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnection.Models
{
    public class SelectCharacterPageModel
    {
        private string login;
        public SelectCharacterPageModel()
        {
            CurrentUser = CreatorDbContext.currentUser;
        }
        public string CurrentUser
        {
            get => login;
            set
            {
                login = value;
            }
        }
    }
}
