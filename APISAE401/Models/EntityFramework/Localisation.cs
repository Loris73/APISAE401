using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_e_localisation_loc")]
    public partial class Localisation
    {
        [Key]
        [Column("loc_id")]
        public int IdLocalisation { get; set; }

        [Required]
        [Column("loc_nom")]
        public string LocalisationNom { get; set; }

        [InverseProperty("LocalisationNavigation")]
        public virtual ICollection<SousLocalisation> SouslocalisationNavigation { get; set; } = new List<SousLocalisation>();

    }
}
