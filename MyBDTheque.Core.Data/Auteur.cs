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
    [Table("Auteur")]
    public class Auteur
    {
        #region Propriétés
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AuteurId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Le nom doit être renseigné.")]
        public string Nom { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Le prénom doit être renseigné.")]
        [DisplayName("Prénom")]
        public string Prenom { get; set; }
        [NotMapped]
        [DisplayName("Nom complet")]
        public string NomComplet { get => Nom + " " + Prenom; }
        [DataType(DataType.Date)]
        [DisplayName("Date de naissance")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [DateCustom(Minimum = "1900/01/01", Maximum = "")]
        public DateTime? DateDeNaissance { get; set; }
        [MaxLength(2000)]
        public string Biographie { get; set; }
        public List<BandeDessineeAuteur> BandeDessineeAuteurs { get; set; }
        #endregion

        #region Constructeurs
        public Auteur()
        {
            BandeDessineeAuteurs = new List<BandeDessineeAuteur>();
            Nom = string.Empty;
            Prenom= string.Empty;
            Biographie = string.Empty;
        }
        #endregion
    }
}
