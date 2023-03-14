using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_e_souslocalisation_slo")]
    public partial class SousLocalisation
    {
        [Column("loc_id")]
        public int IdLocalisation { get; set; }

        [Key]
        [Column("slo_id")]
        public int IdSousLocalisation { get; set; }

        [Column("slo_nom")]
        public string NomSousLocalisation { get; set; }

        [ForeignKey("loc_id")]
        [InverseProperty("SouslocalisationNavigation")]
        public virtual Localisation LocalisationNavigation { get; set; } = null!;

        [InverseProperty("SouslocalisationNavigation")]
        public virtual ICollection<APourSousLoc> ApoursouslocNavigation { get; set; } = new List<APourSousLoc>();

    }
}
