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

        [Key]
        [Column("bar_idclub")]
        public int IdClub { get; set; }

        [Required]
        [Column("bar_nom")]
        [StringLength(255)]
        public string NomBar { get; set; }

        [Required]
        [Column("bar_descritpion")]
        public string DescriptionBar { get; set; }

        //=======================================
        //ForeignKey => IdDomaineSkiable 

        /*----Jules---- => 
         * ForeignKey permettant de recuperer l'IdClub dans le model Bar
         * Modifié le 07/03/2023
         */
        [ForeignKey("IdClub")]
        [InverseProperty("BarClubNavigation")]
        public virtual Club ClubBarNavigation { get; set; } = null!;

        //---------------------------------------------
        //=======================================
        

    }
}
