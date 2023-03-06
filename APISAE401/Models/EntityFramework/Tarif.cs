using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


namespace APISAE401.Models.EntityFramework
{
    public class Tarif
    {

        [Table("t_j_tarif_trf")]
        public partial class Notation
        {
            [Key]
            [Column("tpc_id")]
            public int TypeChambreId { get; set; }

            [Key]
            [Column("clb_id")]
            public int IdClub { get; set; }

            [Key]
            [Column("cld_date", TypeName = "date")]
            [Required]
            public DateTime DateCal { get; set; }

            [Column("trf_prix")]
            [Required]
            public int Note { get; set; }

            [ForeignKey("TypeChambreId")]
            [InverseProperty("TarifChambre")]
            public virtual TypeChambre TypeChambreTarif { get; set; } = null!;

            [ForeignKey("IdClub")]
            [InverseProperty("TarifClub")]
            public virtual Club ClubTarif { get; set; } = null!;

            [ForeignKey("DateCal")]
            [InverseProperty("TarifDate")]
            public virtual Calendrier CalendrierTarif { get; set; } = null!;
        }
    }
}
