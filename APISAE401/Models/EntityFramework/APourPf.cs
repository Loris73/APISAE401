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
        [Column("tpc_id")]
        public int IdTypeChambre { get; set; }

        [Column("ptf_id")]
        public int IdPointFort { get; set; }

        

        //ForeignKey
        [ForeignKey("IdPointFort")]
        [InverseProperty("ApourpfNavigation")]
        public virtual PointFort PointfortNavigation { get; set; } = null!;

        [ForeignKey("IdTypeChambre")]
        [InverseProperty("ApourpfNavigation")]
        public virtual TypeChambre TypechambreNavigation { get; set; } = null!;
    }
}
