using MyBDTheque.BackOffice.WPF.UI.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBDTheque.BackOffice.WPF.UI.Services.DataSample
{
    public interface IDataSample
    {
        void DeleteElement(int ind);
        void AddElement(BandeDessinee bd);
        void EditElement(int id, BandeDessinee bd);
        BandeDessinee GetElement(int id);
        List<BandeDessinee> GetBandeDessinees();
        bool CheckLoginMotDePasse(string login, string mdp);
        bool CheckLogin(string login);
        string AddUser(string login, string mdp);
        //void SetUtilisateurConnecte(string identifiant, string mdp);
        //User GetUtilisateurConnecte();
        int GetIdUtilisateurConnecte();
        int GetIdUtilisateur(string identifiant);
        void SetIdUtilisateurConnecte(int id);
        string GetIdentifiantUtilisateurConnecte();
    }
}
