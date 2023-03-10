using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_j_apourloc_alc")]
    public partial class APourSousLoc
    {
        [Key]
        [Column("clb_id")]
        public int IdClub { get; set; }

        [Key]
        [Column("slo_id")]
        public int IdSousLocalisation { get; set; }

        //ForeignKey

        [ForeignKey("IdSousLocalisation")]
        [InverseProperty("APourSousLocNavigation")]
        public virtual SousLocalisation SousLocalisationNavigation { get; set; } = null!;

        [ForeignKey("IdClub")]
        [InverseProperty("APourSousLocNavigation")]
        public virtual Club ClubNavigation { get; set; } = null!;
    }
}
