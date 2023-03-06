using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_e_commodites_cmd")]
    [Index(nameof(IdCommodites), IsUnique = true)]

    public partial class Commodites
    {
        [Key]
        [Column("cmd_id")]
        public int IdCommodites { get; set; }

        [Required]
        [Column("cmd_typecommodites")]
        [StringLength(255)]
        public string TypeCommodites { get; set; }

        [ForeignKey("IdCommodites")]
        [InverseProperty("NavigationCommodites")]
        public virtual Commodites CommoditesNav { get; set; } = null!;

        public override bool Equals(object? obj)
        {
            return obj is Commodites commodites &&
                   this.IdCommodites == commodites.IdCommodites &&
                   this.TypeCommodites == commodites.TypeCommodites &&
                   EqualityComparer<Commodites>.Default.Equals(this.CommoditesNav, commodites.CommoditesNav);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.IdCommodites, this.TypeCommodites, this.CommoditesNav);
        }
    }
}
