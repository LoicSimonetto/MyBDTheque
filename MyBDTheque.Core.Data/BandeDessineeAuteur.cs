using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBDTheque.Core.Data
{
    [Table("BandeDessineeAuteur")]
    public class BandeDessineeAuteur
    {
        public int BandeDessineeId { get; set; }
        public int AuteurId { get; set; }
        public BandeDessinee BandeDessinee { get; set; }
        public Auteur Auteur { get; set; }
    }
}
