using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_j_detient_dtn")]
    public partial class Detient
    {
        [Key]
        [Column("cc_id")]
        public int IdCarteBancaire { get; set; }

        [Key]
        [Column("clt_id")]
        public int IdClient { get; set; }

        [ForeignKey("IdCarteBancaire")]
        [InverseProperty("DetientNavigation")]
        public virtual CarteBancaire CartebancaireNavigation { get; set; } = null!;

        [ForeignKey("IdClient")]
        [InverseProperty("DetientNavigation")]
        public virtual Client ClientNavigation { get; set; } = null!;
    }
}
