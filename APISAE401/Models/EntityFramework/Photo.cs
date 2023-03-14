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

        [Column("bar_id")]
        public int? IdBar { get; set; }

        [Column("tat_id")]
        public int? IdTypeActivite { get; set; }

        [Column("rsn_id")]
        public int? IdRestaurant { get; set; }

        [Column("skb_id")]
        public int? IdDomaineSkiable { get; set; }

        [Column("clb_id")]
        public int? IdClub { get; set; }

        [Column("tpc_id")]
        public int? IdTypeChambre { get; set; }

        [Required]
        [Column("pht_url")]
        public string Urlphoto { get; set; }

        //=======================================

        //=======================================
        // ForeignKeys => IdBar, IdTypeActivite, IdRestaurant, IdDomaineSkiable, IdClub, IdTypeChambre

        [ForeignKey("IdBar")]
        [InverseProperty("PhotoNavigation")]
        public virtual Bar BarNavigation { get; set; }

        [ForeignKey("IdTypeActivite")]
        [InverseProperty("PhotoNavigation")]
        public virtual TypeActivite TypeactiviteNavigation { get; set; }

        [ForeignKey("IdRestaurant")]
        [InverseProperty("PhotoNavigation")]
        public virtual Restaurant RestaurantNavigation { get; set; }

        [ForeignKey("IdDomaineSkiable")]
        [InverseProperty("PhotoNavigation")]
        public virtual DomaineSkiable DomaineskiableNavigation { get; set; }

        [ForeignKey("IdClub")]
        [InverseProperty("PhotoNavigation")]
        public virtual Club ClubNavigation { get; set; }

        [ForeignKey("IdTypeChambre")]
        [InverseProperty("PhotoNavigation")]
        public virtual TypeChambre TypechambreNavigation { get; set; } = null!;
        //=======================================

        //=======================================
        // InverseProperty =>

        //=======================================
    }
    //------------------------------
}
