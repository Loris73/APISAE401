using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APISAE401.Models.EntityFramework
{
    /*----Jules---- => 
    * Model Reponse
    * Modifié le 08/03/2023 par Jules
    */

    [Table("t_e_photo_pht")]
    [Index(nameof(IdPhoto), IsUnique = true)]

    public partial class Photo
    {
        //=======================================
        //Properties du model Photo
        [Key]
        [Column("pht_id")]
        public int IdPhoto { get; set; }

        [Required]
        [Column("bar_id")]
        public int IdBar { get; set; }

        [Required]
        [Column("tat_id")]
        public int IdTypeActivite { get; set; }

        [Required]
        [Column("rsn_id")]
        public int IdRestaurant { get; set; }

        [Required]
        [Column("skb_id")]
        public int IdDomaineSkiable { get; set; }

        [Required]
        [Column("clb_id")]
        public int IdClub { get; set; }

        [Required]
        [Column("tpc_id")]
        public int IdTypeChambre { get; set; }

        [Required]
        [Column("pht_titre")]
        public string photo { get; set; }

        //=======================================

        //=======================================
        // ForeignKeys => IdBar, IdTypeActivite, IdRestaurant, IdDomaineSkiable, IdClub, IdTypeChambre

        [ForeignKey("IdBar")]
        [InverseProperty("PhotoBarNavigation")]
        public virtual Bar BarPhotoNavigation { get; set; } = new Bar();

        [ForeignKey("IdTypeActivite")]
        [InverseProperty("PhotoTypeActiviteNavigation")]
        public virtual TypeActivite TypeActivitePhotoNavigation { get; set; } = new TypeActivite();

        [ForeignKey("IdRestaurant")]
        [InverseProperty("PhotoRestaurantNavigation")]
        public virtual Restaurant RestaurantPhotoNavigation { get; set; } = new Restaurant();

        [ForeignKey("IdDomaineSkiable")]
        [InverseProperty("PhotoDomaineSkiableNavigation")]
        public virtual DomaineSkiable DomaineSkiablePhotoNavigation { get; set; } = new DomaineSkiable();

        [ForeignKey("IdClub")]
        [InverseProperty("PhotoClubNavigation")]
        public virtual Club ClubPhotoNavigation { get; set; } = new Club();

        [ForeignKey("IdTypeChambre")]
        [InverseProperty("PhotoTypeChambreNavigation")]
        public virtual TypeChambre TypeChambrePhotoNavigation { get; set; } = new TypeChambre();
        //=======================================

        //=======================================
        // InverseProperty =>

        //=======================================
    }
    //------------------------------
}
