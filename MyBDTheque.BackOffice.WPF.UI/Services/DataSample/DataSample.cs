using MyBDTheque.BackOffice.WPF.UI.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBDTheque.BackOffice.WPF.UI.Services.DataSample
{
    public class DataSample : IDataSample
    {
        public List<BandeDessinee> MesBandeDessinees { get; set; }
        public List<User> Users { get; set; }
        //public User UtilisateurConnecte { get; private set; }
        public int IdUtilisateurConnecte { get; private set; }
        public DataSample()
        {
            MesBandeDessinees = new List<BandeDessinee>();
            for (int i = 0; i < 5; i++)
            {
                MesBandeDessinees.Add(new BandeDessinee()
                {
                    Titre = "Bande dessinée n° " + (i + 1).ToString(),
                    Serie = "Ma première série",
                    DateDeSortie = (new DateTime(2005, 10, 1)).AddDays(i)
                });
            }

            Users = new List<User>();
            Users.Add(new User("LoloSitto", "Prout"));
            Users.Add(new User("Invite", "Invite"));

            //UtilisateurConnecte = new User();
            IdUtilisateurConnecte = -1;
        }

        public void AddElement(BandeDessinee bd)
        {
            MesBandeDessinees.Add(bd);
        }

        public void DeleteElement(int ind)
        {
            if (ind < MesBandeDessinees.Count)
            {
                MesBandeDessinees.RemoveAt(ind);
            }
        }

        public void EditElement(int ind, BandeDessinee bd)
        {
            if (ind < MesBandeDessinees.Count)
            {
                MesBandeDessinees[ind] = bd;
            }
        }

        public BandeDessinee GetElement(int ind)
        {
            if (ind < MesBandeDessinees.Count)
            {
                return MesBandeDessinees[ind];
            }
            return null;
        }
        public List<BandeDessinee> GetBandeDessinees()
        {
            return MesBandeDessinees;
        }

        public bool CheckLoginMotDePasse(string login, string mdp)
        {
            bool res = false;

            for (int i = 0; i < Users.Count; i++)
            {
                if (Users[i].MotDePasse == mdp && Users[i].Login == login)
                {
                    res = true;
                    break;
                }
            }

            return res;
        }

        public bool CheckLogin(string login)
        {
            bool res = false;

            for (int i = 0; i < Users.Count; i++)
            {
                if (Users[i].Login == login)
                {
                    res = true;
                    break;
                }
            }

            return res;
        }

        public string AddUser(string login, string mdp)
        {
            string res = "";

            if (Users.Any(u => u.Login == login))
            {
                res = "Cet utilisateur existe déjà.";
            }
            else if (login == null | login == "")
            {
                res = "Il faut saisir un login.";
            }
            else if (mdp == null | mdp == "")
            {
                res = "Il faut saisir un mot de passe.";
            }
            else
            {
                Users.Add(new User(login,mdp));
            }

            return res;
        }

        //public void SetUtilisateurConnecte(string identifiant, string mdp)
        //{
        //    UtilisateurConnecte = new User(identifiant, mdp);
        //}
        //public User GetUtilisateurConnecte()
        //{
        //    return UtilisateurConnecte;
        //}

        public int GetIdUtilisateurConnecte()
        {
            return IdUtilisateurConnecte;
        }
        public void SetIdUtilisateurConnecte(int id)
        {
            IdUtilisateurConnecte = id;
        }

        public int GetIdUtilisateur(string identifiant)
        {
            User user = Users.Find(u => u.Login == identifiant);
            if (user == null)
            {
                return -1;
            }
            else
            {
                return Users.IndexOf(user);
            }
        }

        public string GetIdentifiantUtilisateurConnecte()
        {
            User user = Users.ElementAt(IdUtilisateurConnecte);
            return user.Login;
        }
    }
}
