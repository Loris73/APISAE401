using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APISAE401.Models.EntityFramework
{
    /*----Jules---- => 
    * Model Bar
    * Modifié le 07/03/2023 par Jules
    */
    [Table("t_e_bar_bar")]
    [Index(nameof(IdBar), IsUnique = true)]

    public partial class Bar
    {
        [Key]
        [Column("bar_id")]
        public int IdBar { get; set; }

        [Column("clb_id")]
        public int IdClub { get; set; }

        [Required]
        [Column("bar_nom")]
        public string NomBar { get; set; }

        [Required]
        [Column("bar_description")]
        public string DescriptionBar { get; set; }

        //=======================================
        //ForeignKey => IdDomaineSkiable 

        /*----Jules---- => 
         * ForeignKey permettant de recuperer l'IdClub dans le model Bar
         * Modifié le 07/03/2023
         */
        [ForeignKey("IdClub")]
        [InverseProperty("BarNavigation")]
        public virtual Club ClubNavigation { get; set; } = null!;

        //---------------------------------------------
        //=======================================
        // InverseProperty permettant de recuperer l'IdBar dans la table Photo
        [InverseProperty("BarNavigation")]
        public virtual ICollection<Photo> PhotoNavigation { get; set; } = new List<Photo>();


    }
}
