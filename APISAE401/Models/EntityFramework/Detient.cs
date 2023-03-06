using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_j_detient_dtn")]
    public partial class Detient
    {
        [Key]
        [Column("cc_idcartebancaire")]
        public int IdCarteBancaire { get; set; }

        [Key]
        [Column("clt_id")]
        public int IdClient { get; set; }

        [ForeignKey("IdCarteBancaire")]
        [InverseProperty("DetientCarteBancaire")]
        public virtual ICollection<CarteBancaire> CarteBancaireNaviguation { get; set; } = new List<CarteBancaire>();

        [ForeignKey("IdClient")]
        [InverseProperty("DetientClient")]
        public virtual Client ClientNavigation { get; set; } = null!;
    }
}
