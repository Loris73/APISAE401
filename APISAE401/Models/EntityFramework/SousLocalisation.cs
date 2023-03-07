using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_j_souslocalisation_slo")]
    public partial class SousLocalisation
    {
        [Key]
        [Column("loc_id")]
        public int IdLocalisation { get; set; }

        [Key]
        [Column("loc_sousloc_id")]
        public int IdSousLocalisation { get; set; }

        [ForeignKey("loc_id")]
        [InverseProperty("APourLoc")]
        public virtual Localisation LocalisationNavigation { get; set; } = null!;

        [ForeignKey("loc_sousloc_id")]
        [InverseProperty("APourSousLoc")]
        public virtual Localisation SousLocalisationNavigation { get; set; } = null!;

        public override bool Equals(object? obj)
        {
            return obj is SousLocalisation localisation &&
                   IdLocalisation == localisation.IdLocalisation &&
                   IdSousLocalisation == localisation.IdSousLocalisation &&
                   EqualityComparer<Localisation>.Default.Equals(LocalisationNavigation, localisation.LocalisationNavigation) &&
                   EqualityComparer<Localisation>.Default.Equals(SousLocalisationNavigation, localisation.SousLocalisationNavigation);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(IdLocalisation, IdSousLocalisation, LocalisationNavigation, SousLocalisationNavigation);
        }
    }
}
