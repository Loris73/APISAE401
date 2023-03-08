using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace APISAE401.Models.EntityFramework
{
    [Table("t_j_apourpf_apf")]
    public class APourPf
    {        
        [Key]
        [Column("ptf_id")]
        public int IdPointFort { get; set; }

        [Key]
        [Column("tpc_id")]
        public int TypeChambreId { get; set; }

        //ForeignKey
        [ForeignKey("IdPointFort")]
        [InverseProperty("ApourpfNavigation")]
        public virtual PointFort PointFortNaviguation { get; set; } = null!;

        [ForeignKey("TypeChambreId")]
        [InverseProperty("ApourpfNavigation")]
        public virtual TypeChambre TypeChambreNavigation { get; set; } = null!;
    }
}
