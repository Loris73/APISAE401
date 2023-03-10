using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_j_avoircomme_ace")]
    public class AvoirComme
    {
        [Key]
        [Column("sct_id")]
        public int IdServiceCommodites { get; set; }

        [Key]
        [Column("tpc_id")]
        public int IdTypeChambre { get; set; }

        //-----------------------
        // ForeignKey
        [ForeignKey("IdServiceCommodite")]
        [InverseProperty("AvoirCommeNavigation")]
        public virtual ServiceCommodite ServiceCommoditeNavigation { get; set; } = null!;

        [ForeignKey("IdTypeChambre")]
        [InverseProperty("AvoirCommeNavigation")]
        public virtual TypeChambre TypeChambreNavigation { get; set; } = null!;

    }
}
