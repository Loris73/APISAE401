using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APISAE401.Models.EntityFramework
{
    /*----Jules---- => 
    * Model Commodites
    * Modifié le 07/03/2023 par Jules
    */

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
        //=======================================

        //=======================================
        //InverseProperty => IdCommodites

        /*----Jules---- => 
         * InverseProperty permettant de Recuperer l'IdCommodites dans la table ServiceCommodites
         * Modifié le 07/03/2023
         */

        [InverseProperty("CommoditesNavigation")]
        public virtual ICollection<Commodites> ServiceCommoditesNavigation { get; set; } = new List<Commodites>();

        //----------------------------------------------
    }
    //------------------------------
}
