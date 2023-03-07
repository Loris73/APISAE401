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

        [Required]
        [ForeignKey("cmd_id")]
        [InverseProperty("CommoditesNavigation")]
        public virtual ICollection<Commodites> IdCommodites { get; set; } = new List<Commodites>();

        [Required]
        [Column("sct_nom")]
        [StringLength(255)]
        public string NomServiceCommodites { get; set; }

        [InverseProperty("ServiceCommoditesNaviguation")]
        public virtual ICollection<AvoirComme> AvoirCommeServiceCommodites { get; set; } = new List<AvoirComme>();

    }
}
