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


            [ForeignKey("PointFortId")]
            [InverseProperty("APourPointFort")]
            public virtual PointFort PointfortNaviguation { get; set; } = null!;

            [ForeignKey("TypeChambreId")]
            [InverseProperty("APourTypeChambre")]
            public virtual TypeChambre TypeChambreNavigation { get; set; } = null!;

        public override bool Equals(object? obj)
        {
            return obj is APourPf pf &&
                   this.PointFortId == pf.PointFortId &&
                   this.TypeChambreId == pf.TypeChambreId &&
                   EqualityComparer<PointFort>.Default.Equals(this.PointfortNaviguation, pf.PointfortNaviguation) &&
                   EqualityComparer<TypeChambre>.Default.Equals(this.TypeChambreNavigation, pf.TypeChambreNavigation);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.PointFortId, this.TypeChambreId, this.PointfortNaviguation, this.TypeChambreNavigation);
        }
    }
}
