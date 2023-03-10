using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_e_regroupement_rgt")]
    public partial class Regroupement 
    {
        [Key]
        [Column("rgt_id")]
        public int RegroupementId { get; set; }

        [Required]
        [Column("rgt_nom")]
        [StringLength(255)]
        public string? RegroupementNom { get; set; }


        [InverseProperty("RegroupementNavigation")]
        public virtual ICollection<Regrouper> RegrouperNavigation { get; set; } = new List<Regrouper>();
    }
}
