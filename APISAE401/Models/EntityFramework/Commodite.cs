using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APISAE401.Models.EntityFramework
{
    /*----Jules---- => 
    * Model Commodites
    * Modifié le 08/03/2023 par Jules
    */

    [Table("t_e_commodites_cmd")]
    [Index(nameof(IdCommodite), IsUnique = true)]

    public partial class Commodite
    {
        [Key]
        [Column("cmd_id")]
        public int IdCommodite { get; set; }

        [Required]
        [Column("cmd_typecommodite")]
        [StringLength(255)]
        public string TypeCommodite { get; set; }
        //=======================================

        //=======================================
        //InverseProperty => IdCommodites

        /*----Jules---- => 
         * InverseProperty permettant de Recuperer l'IdCommodites dans la table ServiceCommodites
         * Modifié le 07/03/2023
         */

        [InverseProperty("CommoditeNavigation")]
        public virtual ICollection<Commodite> ServiceCommoditeNavigation { get; set; } = new List<Commodite>();

        //----------------------------------------------
    }
    //------------------------------
}
