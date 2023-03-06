using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Net.Sockets;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_e_reservation_rsv")]
    public class Reservation
    {
        [Key]
        [Column("rsv_idreservation")]
        public int IdReservation { get; set; }

        [Column("rsv_datereservation", TypeName = "date")]
        public DateTime DateReservation { get; set; }

        [Column("rsv_montant")]
        public decimal Montant { get; set; }

        // ForeignKey : idClub, IdClient, dateCal à faire
        [InverseProperty("ReservationNavigation")]
        public virtual ICollection<Participer> ParticiperReservation { get; set;} = new List<Participer>();

        [InverseProperty("TransportNavigation")]
        public virtual ICollection<Deplacer> DeplacerTransport { get; set; } = new List<Deplacer>();
    }
}
