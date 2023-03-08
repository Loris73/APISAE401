using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_j_avoircomme_ace")]
    public class AvoirComme
    {
        [Key]
        [Column("ace_idservicecommodite")]
        public int IdServiceCommodites { get; set; }

        [Key]
        [Column("ace_idtypechambre")]
        public int IdTypeChambre { get; set; }

        //-----------------------
        [ForeignKey("IdServiceCommodite")]
        [InverseProperty("AvoirCommeServiceCommodite")]
        public virtual ServiceCommodite ServiceCommoditeNaviguation { get; set; } = null!;

        [ForeignKey("IdTypeChambre")]
        [InverseProperty("AvoirCommeTypeChambre")]
        public virtual TypeChambre TypeChambreNavigation { get; set; } = null!;
        //-----------------------

        [InverseProperty("CommoditeAvoirCommeNavigation")]
        public virtual ICollection<Commodite> AvoirCommeCommoditeNavigation { get; set; } = new List<Commodite>();

    }
}
