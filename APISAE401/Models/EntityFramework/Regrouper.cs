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
        [InverseProperty("RegroupementNav")]
        public virtual ICollection<Regroupement> APourRegroupement { get; set; } = new List<Regroupement>();

        [ForeignKey("IdClub")]
        [InverseProperty("RegroupementNav")]
        public virtual ICollection<Club> APourClub { get; set; } = new List<Club>();
    }
}
