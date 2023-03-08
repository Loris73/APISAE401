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
        public int PointFortId { get; set; }

        [Key]
        [Column("tpc_id")]
        public int TypeChambreId { get; set; }

        //ForeignKey
        [ForeignKey("PointFortId")]
        [InverseProperty("APourPointFort")]
        public virtual PointFort PointfortNaviguation { get; set; } = null!;

        [ForeignKey("TypeChambreId")]
        [InverseProperty("APourTypeChambre")]
        public virtual TypeChambre TypeChambreNavigation { get; set; } = null!;
    }
}
