using MyBDTheque.Core.Data.CustomValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBDTheque.Core.Data
{
    [Table("BandeDessinee")]
    public class BandeDessinee
    {
        #region Propriétés
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BandeDessineeId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Le titre doit être défini.")]
        public string Titre { get; set; }
        [DisplayName("Resumé")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Le résumé doit être défini.")]
        public string Resume { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Date de sortie")]
        [DisplayFormat(DataFormatString = "{0:MM-yyyy}", ApplyFormatInEditMode = false)]
        [DateCustomAttribute(Minimum = "1900/01/01", Maximum = "")]
        public DateTime DateParution { get; set; }
        [DisplayName("Auteur")]
        public List<BandeDessineeAuteur> BandeDessineeAuteurs { get; set; }
        public int? SerieId { get; set; }
        [DisplayName("Série")]
        public Serie? Serie { get; set; }
        #endregion

        #region Constructeurs
        public BandeDessinee()
        {
            BandeDessineeAuteurs = new List<BandeDessineeAuteur>();
            Titre = string.Empty;
            Resume = string.Empty;
        }
        #endregion
    }
}
