using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_e_restaurant_rsn")]
    [Index(nameof(IdRestaurant), IsUnique = true)]

    public partial class Restaurant
    {
        [Key]
        [Column("rsn_id")]
        public int IdRestaurant { get; set; }

        [Key]
        [Column("rsn_idclub")]
        public int IdClub { get; set; }

        [Required]
        [Column("rsn_nom")]
        [StringLength(255)]
        public string NomRestaurant { get; set; }

        [Required]
        [Column("rsn_descritpion")]
        public string DescriptionRestaurant { get; set; }

        //=======================================
        //ForeignKey => IdDomaineSkiable 

        /*----Jules---- => 
         * ForeignKey permettant de recuperer l'IdClub dans le model Restaurant
         * Modifié le 07/03/2023
         */
        [ForeignKey("IdClub")]
        [InverseProperty("RestaurantClubNavigation")]
        public virtual Club ClubRestaurantNavigation { get; set; } = null!;

        //---------------------------------------------
        //=======================================

    }
}
