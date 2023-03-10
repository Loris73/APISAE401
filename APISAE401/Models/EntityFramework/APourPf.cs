﻿using System;
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
        [Column("tpc_id")]
        public int IdTypeChambre { get; set; }

        [Key]
        [Column("ptf_id")]
        public int IdPointFort { get; set; }

        

        //ForeignKey
        [ForeignKey("IdPointFort")]
        [InverseProperty("APourPFNavigation")]
        public virtual PointFort PointFortNavigation { get; set; } = null!;

        [ForeignKey("IdTypeChambre")]
        [InverseProperty("ApourPFNavigation")]
        public virtual TypeChambre TypeChambreNavigation { get; set; } = null!;
    }
}
