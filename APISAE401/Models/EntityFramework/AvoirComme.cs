using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_j_avoircomme_ace")]
    public class AvoirComme
    {
        [Key]
        [Column("ace_idservicecommodites")]
        public int IdServiceCommodites { get; set; }

        [Key]
        [Column("ace_idtypechambre")]
        public int IdTypeChambre { get; set; }


        [ForeignKey("IdServiceCommodites")]
        [InverseProperty("AvoirCommeServiceCommodites")]
        public virtual ServiceCommodites ServiceCommoditesNaviguation { get; set; } = null!;

        [ForeignKey("IdTypeChambre")]
        [InverseProperty("AvoirCommeTypeChambre")]
        public virtual TypeChambre TypeChambreNavigation { get; set; } = null!;

        public override bool Equals(object? obj)
        {
            return obj is AvoirComme comme &&
                   this.IdServiceCommodites == comme.IdServiceCommodites &&
                   this.IdTypeChambre == comme.IdTypeChambre &&
                   EqualityComparer<ServiceCommodites>.Default.Equals(this.ServiceCommoditesNaviguation, comme.ServiceCommoditesNaviguation) &&
                   EqualityComparer<TypeChambre>.Default.Equals(this.TypeChambreNavigation, comme.TypeChambreNavigation);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.IdServiceCommodites, this.IdTypeChambre, this.ServiceCommoditesNaviguation, this.TypeChambreNavigation);
        }
    }
}
