using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_j_regrouper_rgr")]
    public class Regrouper
    {
        [Column("rgt_id")]
        public int RegroupementId { get; set; }

        [Column("clb_id")]
        public int IdClub { get; set; }

        [ForeignKey("RegroupementId")]
        [InverseProperty("RegrouperNavigation")]
        public virtual Regroupement RegroupementNavigation { get; set; } = null!;

        [ForeignKey("IdClub")]
        [InverseProperty("RegrouperNavigation")]
        public virtual Club ClubNavigation { get; set; } = null!;
    }
}
