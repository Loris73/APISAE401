
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

        [ForeignKey("IdClub")]
        [InverseProperty("APourLocNavigation")]
        public virtual Localisation LocalisationNavigation { get; set; } = null!;

        [ForeignKey("IdLocalisation")]
        [InverseProperty("APourLocNavigation")]
        public virtual Club ClubNavigation { get; set; } = null!;
    }
}
