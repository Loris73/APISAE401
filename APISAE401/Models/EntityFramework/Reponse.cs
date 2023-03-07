using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APISAE401.Models.EntityFramework
{
    /*----Jules---- => 
    * Model Reponse
    * Modifié le 07/03/2023 par Jules
    */

    [Table("t_e_reponse_rps")]
    [Index(nameof(IdReponse), IsUnique = true)]

    public partial class Reponse
    {
        //=======================================
        //Properties du model Reponse
        [Key]
        [Column("rps_id")]
        public int IdReponse { get; set; }

        [Required]
        [Column("clt_id")]
        public int IdClient { get; set; }

        [Required]
        [Column("clb_id")]
        public int IdClub { get; set; }

        [Required]
        [Column("avi_id")]
        public int IdAvis { get; set; }

        [Required]
        [Column("rps_titre")]
        [StringLength(50)]
        public string TitreReponse { get; set; }

        [Required]
        [Column("rps_commentaire")]
        public string CommentaireReponse { get; set; }
        //=======================================

        //=======================================
        //ForeignKeys => IdClient, IdClub, IdAvis

        [ForeignKey("IdClient")]
        [InverseProperty("ReponsesNavigation")]
        public virtual Client ClientNavigation { get; set; } = new Client();

        [ForeignKey("IdClub")]
        [InverseProperty("ReponsesNavigation")]
        public virtual Club ClubNavigation { get; set; } = new Club();

        [ForeignKey("IdAvis")]
        [InverseProperty("ReponsesNavigation")]
        public virtual Avis AvisNavigation { get; set; } = new Avis();
        //=======================================
    }
    //------------------------------
}
