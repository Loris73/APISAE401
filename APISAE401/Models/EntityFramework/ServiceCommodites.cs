using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APISAE401.Models.EntityFramework
{
    /*----Jules---- => 
    * Model Reponse
    * Modifié le 07/03/2023 par Jules
    */

    [Table("t_e_servicecommodites_sct")]
    [Index(nameof(IdServiceCommodites), IsUnique = true)]

    public partial class ServiceCommodites
    {
        [Key]
        [Column("sct_id")]
        public int IdServiceCommodites { get; set; }

        [Required]
        [Column("cmd_id")]
        public int IdCommodites { get; set; }

        [Required]
        [Column("sct_nom")]
        [StringLength(255)]
        public string NomServiceCommodites { get; set; }
        //==========================================================================================================

        //==========================================================================================================
        //ForeignKeys => IdClient, IdClub, IdAvis

        [ForeignKey("IdCommodites")]
        [InverseProperty("ServiceCommoditesNavigation")]
        public virtual Commodites CommoditesNavigation { get; set; } = new Commodites();

        //==========================================================================================================



    }
    //------------------------------
}
