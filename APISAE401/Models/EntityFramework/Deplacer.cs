using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_j_deplacer_dpc")]
    public partial class Deplacer
    {
        [Column("tsp_id")]
        public int IdTransport { get; set; }


        [Column("rsv_idreservation")]
        public int IdReservation { get; set; }

        [Required]
        [Column("dcp_lieu")]
        [StringLength(255)]
        public string? DeplacerLieu { get; set; }

        [Required]
        [Column("dcp_montant")]
        public int DeplacerMontant { get; set; }

        [ForeignKey("IdTransport")]
        [InverseProperty("DeplacerNavigation")]
        public virtual Transport TransportNavigation { get; set; }

        [ForeignKey("IdReservation")]
        [InverseProperty("DeplacerNavigation")]
        public virtual Reservation ReservationNavigation { get; set; }

    }
}
