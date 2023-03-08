﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APISAE401.Models.EntityFramework
{
    /*----Jules---- => 
    * Model ServiceCommodites
    * Modifié le 08/03/2023 par Jules
    */

    [Table("t_e_servicecommodite_sct")]
    [Index(nameof(IdServiceCommodite), IsUnique = true)]

    public partial class ServiceCommodite
    {
        [Key]
        [Column("sct_id")]
        public int IdServiceCommodite { get; set; }

        [Required]
        [Column("cmd_id")]
        public int IdCommodite { get; set; }

        [Required]
        [Column("sct_nom")]
        [StringLength(255)]
        public string NomServiceCommodite { get; set; }
        //==========================================================================================================

        //==========================================================================================================
        //ForeignKeys => IdClient, IdClub, IdAvis

        [ForeignKey("IdCommodite")]
        [InverseProperty("ServiceCommoditeCommoditeNavigation")]
        public virtual Commodite ServiceCommoditeCommoditeNavigation { get; set; } = new Commodite();

        //==========================================================================================================



    }
    //------------------------------
}
