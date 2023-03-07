
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APISAE401.Models.EntityFramework
{
    public partial class APourLoc
    {
        [Key]
        [Column("clb_id")]
        public int IdClub { get; set; }

        [Key]
        [Column("loc_id")]
        public int IdLocalisation { get; set; }

        [ForeignKey("clb_id")]
        [InverseProperty("APourLoc")]
        public virtual Localisation LocalisationNav { get; set; } = null!;

        [ForeignKey("loc_id")]
        [InverseProperty("APourClub")]
        public virtual Club LocNavNavigation { get; set; } = null!;
    }
}
