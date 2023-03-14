using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_e_typeactivite_tat")]
    [Index(nameof(IdTypeActivite), IsUnique = true)]

    public partial class TypeActivite
    {
        [Key]
        [Column("tat_id")]
        public int IdTypeActivite { get; set; }

        [Required]
        [Column("tat_nom")]
        public string NomTypeActivite { get; set; }

        [Required]
        [Column("tat_description")]
        public string DescriptionTypeActivite { get; set; }

        //=======================================

        /*----Lucas---- => 
         * InverseProperty permettant de Recuperer l'IdTypeActivite dans la table Activite
         * Modifié le 08/03/2023
         */

        [InverseProperty("TypeactiviteNavigation")]
       public virtual ICollection<Activite> ActiviteNavigation { get; set; } = new List<Activite>();

        // InverseProperty permettant de recuperer l'IdTypeActivite dans la table Photo
        [InverseProperty("TypeactiviteNavigation")]
        public virtual ICollection<Photo> PhotoNavigation { get; set; } = new List<Photo>();

        


    }
}
