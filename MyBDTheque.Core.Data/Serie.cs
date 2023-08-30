using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MyBDTheque.Core.Data
{
    [Table("Serie")]
    public class Serie
    {
        #region Propriétés
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SerieId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Le titre doit être défini.")]
        public string Titre { get; set; }
        [DisplayName("Résumé")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Le résumé doit être défini.")]
        public string Resume { get; set; }
        public List<BandeDessinee>? BandeDessinees { get; set; }
        #endregion

        #region Constructeurs
        public Serie()
        {
            Titre = string.Empty;
            Resume = string.Empty;
        }
        #endregion
    }
}
