using MyBDTheque.BackOffice.WPF.UI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBDTheque.BackOffice.WPF.UI.MVVM.Models
{
    public class BandeDessinee : ElementType
    {
        public string Titre { get; set; }
        public string Serie { get; set; }
        public DateTime DateDeSortie { get; set; }
        public int? Tome { get; set; }
        public string Auteurs { get; set; }

        public BandeDessinee()
        {

        }
        public BandeDessinee(BandeDessinee original)
        {
            Titre = original.Titre;
            Serie = original.Serie;
            DateDeSortie = original.DateDeSortie;
            Tome = original.Tome;
            Auteurs = original.Auteurs;
        }
    }
}
