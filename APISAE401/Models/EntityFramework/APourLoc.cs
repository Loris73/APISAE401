using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_j_apourloc_alc")]
    public partial class APourLoc
    {
        [Key]
        [Column("clb_id")]
        public int IdClub { get; set; }

        [Key]
        [Column("loc_id")]
        public int IdLocalisation { get; set; }

        //ForeignKey

        [ForeignKey("IdLocalisation")]
        [InverseProperty("ApourlocNavigation")]
        public virtual Localisation LocalisationNavigation { get; set; } = null!;

        [ForeignKey("IdClub")]
        [InverseProperty("ApourlocNavigation")]
        public virtual Club ClubNavigation { get; set; } = null!;
    }
}
