using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APISAE401.Models.EntityFramework
{
    public partial class Regroupement
    {
        [Table("t_e_regroupement_rgt")]


        public partial class TypeChambre
        {
            [Key]
            [Column("rgt_id")]
            public int RegroupementId { get; set; }

            [Required]
            [Column("rgt_nom")]
            [StringLength(255)]
            public string? RegroupementNom { get; set; }


            [InverseProperty("RegroupementNav")]
            public virtual ICollection<Regrouper> APourRegroupement { get; set; } = new List<Regrouper>();

        }
    }
}
