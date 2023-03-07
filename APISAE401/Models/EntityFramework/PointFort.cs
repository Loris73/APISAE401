using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace APISAE401.Models.EntityFramework
{
        [Table("t_e_pointfort_ptf")]
    public class PointFort
    {


        
            [Key]
            [Column("ptf_id")]
            public int PointFortId { get; set; }

            [Required]
            [Column("ptf_nom")]
            [StringLength(255)]
            public string? PointFortNom { get; set; }

            [InverseProperty("PointFortNaviguation")]
            public virtual ICollection<APourPf> APourPointFort { get; set; } = new List<APourPf>();

        public override bool Equals(object? obj)
        {
            return obj is PointFort fort &&
                   PointFortId == fort.PointFortId &&
                   PointFortNom == fort.PointFortNom &&
                   EqualityComparer<ICollection<APourPf>>.Default.Equals(APourPointFort, fort.APourPointFort);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(PointFortId, PointFortNom, APourPointFort);
        }
    }
}
