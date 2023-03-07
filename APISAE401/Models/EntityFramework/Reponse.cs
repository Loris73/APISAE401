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
        [Key]
        [Column("rps_id")]
        public int IdReponse { get; set; }

        [ForeignKey("clt_id")]
        [InverseProperty("ReponsesNavigation")]
        public virtual Client IdClient { get; set; } = new Client();

        [ForeignKey("clb_id")]
        [InverseProperty("ReponsesNavigation")]
        public virtual Club IdClub { get; set; } = new Club();

        [ForeignKey("avi_id")]
        [InverseProperty("ReponsesNavigation")]
        public virtual Avis IdAvis { get; set; } = new Avis();

        [Required]
        [Column("rps_titre")]
        [StringLength(50)]
        public string TitreReponse { get; set; }

        [Required]
        [Column("rps_commentaire")]
        public string CommentaireReponse { get; set; }

    }
    //------------------------------
}
