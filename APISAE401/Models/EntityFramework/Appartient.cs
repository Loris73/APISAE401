using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_j_appartient_ape")]
    public class Appartient
    {
        [Key]
        [Column("clb_id")]
        public int IdClub { get; set; }

        [Key]
        [Column("skb_id")]
        public int IdDommaineSkiable { get; set; }

        [Key]
        [Column("ape_altitude")]
        public double altitudeClub { get; set; }

        //ForeignKey
        [ForeignKey("IdClub")]
        [InverseProperty("AppartientNavigation")]
        public virtual Club ClubNavigation { get; set; } = null!;

        [ForeignKey("IdDommaineSkiable")]
        [InverseProperty("AppartientNavigation")]
        public virtual DomaineSkiable DomaineskiableNavigation { get; set; } = null!;
    }
}
