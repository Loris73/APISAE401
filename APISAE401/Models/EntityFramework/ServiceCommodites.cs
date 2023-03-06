using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_e_servicecommodites_sct")]
    [Index(nameof(IdServiceCommodites), IsUnique = true)]

    public partial class ServiceCommodites
    {
        [Key]
        [Column("sct_id")]
        public int IdServiceCommodites { get; set; }

        [Key]
        [Column("sct_idcommodites")]
        public int IdCommodites { get; set; }

        [Required]
        [Column("sct_nom")]
        [StringLength(255)]
        public string NomServiceCommodites { get; set; }

        [InverseProperty("CommoditesNav")]
        public virtual ICollection<Commodites> NavigationCommodites { get; set; } = new List<Commodites>();

        [InverseProperty("ServiceCommoditesNaviguation")]
        public virtual ICollection<AvoirComme> AvoirCommeServiceCommodites { get; set; } = new List<AvoirComme>();

        public override bool Equals(object? obj)
        {
            return obj is ServiceCommodites commodites &&
                   this.IdServiceCommodites == commodites.IdServiceCommodites &&
                   this.IdCommodites == commodites.IdCommodites &&
                   this.NomServiceCommodites == commodites.NomServiceCommodites &&
                   EqualityComparer<ICollection<Commodites>>.Default.Equals(this.NavigationCommodites, commodites.NavigationCommodites);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.IdServiceCommodites, this.IdCommodites, this.NomServiceCommodites, this.NavigationCommodites);
        }
    }
}
