using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_j_regrouper_rgr")]
    public class Regrouper
    {
        [Key]
        [Column("rgt_id")]
        public int RegroupementId { get; set; }

        [Key]
        [Column("clb_id")]
        public int IdClub { get; set; }

        [ForeignKey("RegroupementId")]
        [InverseProperty("RegrouperNavigation")]
        public virtual ICollection<Regroupement> RegroupementNavigation { get; set; } = new List<Regroupement>();

        [ForeignKey("IdClub")]
        [InverseProperty("RegrouperNavigation")]
        public virtual ICollection<Club> ClubNavigation { get; set; } = new List<Club>();
    }
}
