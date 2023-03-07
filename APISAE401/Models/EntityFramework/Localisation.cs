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
        [StringLength(255)]
        public string? LocalisationNom { get; set; }



        [InverseProperty("LocalisationNavigation")]
        public virtual Localisation Apourloc { get; set; } = null!;

        public override bool Equals(object? obj)
        {
            return obj is Localisation localisation &&
                   IdLocalisation == localisation.IdLocalisation &&
                   LocalisationNom == localisation.LocalisationNom &&
                   EqualityComparer<Localisation>.Default.Equals(Apourloc, localisation.Apourloc);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(IdLocalisation, LocalisationNom, Apourloc);
        }
    }
}
