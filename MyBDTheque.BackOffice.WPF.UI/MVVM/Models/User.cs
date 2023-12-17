using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBDTheque.BackOffice.WPF.UI.MVVM.Models
{
    public class User
    {
        public string Login { get; set; }
        public string MotDePasse { get; set; }

        public User()
        {

        }
        public User(string login, string mdp)
        {
            Login = login;
            MotDePasse = mdp;
        }
    }
}
