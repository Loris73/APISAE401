using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APISAE401.Models.EntityFramework
{
    /*----Jules---- => 
    * Model Reponse
    * Modifié le 07/03/2023 par Jules
    */

    [Table("t_e_photo_pht")]
    [Index(nameof(IdPhoto), IsUnique = true)]

    public partial class Photo
    {
        //=======================================
        //Properties du model Reponse
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
        // ForeignKeys => IdClient, IdClub, IdAvis

        [ForeignKey("IdClient")]
        [InverseProperty("ReponsesClientNavigation")]
        public virtual Client ClientReponsesNavigation { get; set; } = new Client();

        [ForeignKey("IdClub")]
        [InverseProperty("ReponsesClubNavigation")]
        public virtual Club ClubReponsesNavigation { get; set; } = new Club();

        [ForeignKey("IdAvis")]
        [InverseProperty("ReponsesNavigation")]
        public virtual Avis AvisNavigation { get; set; } = new Avis();
        //=======================================

        //=======================================
        // InverseProperty => IdClient, IdClub, IdAvis

        //=======================================
    }
    //------------------------------
}
