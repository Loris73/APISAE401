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


        //inverse property a faire
        //[InverseProperty("TransportNaviguation")]
        //public virtual ICollection<Deplacer> DeplacerTransport { get; set; } = new List<Deplacer>();
    }
}
