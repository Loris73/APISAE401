using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace APISAE401.Models.EntityFramework
{
    [Table("t_e_pointfort_ptf")]
    [Index(nameof(IdPointFort), IsUnique = true)]
    public class PointFort
    {        
            [Key]
            [Column("ptf_id")]
            public int IdPointFort { get; set; }

            [Required]
            [Column("ptf_nom")]
            public string NomPointFort { get; set; }

            [InverseProperty("PointfortNavigation")]
            public virtual ICollection<APourPf> ApourpfNavigation { get; set; } = new List<APourPf>();

    }
}
