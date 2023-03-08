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

        // Id Client
        [Column("clt_id")]
        public int IdClient { get; set; }

        [ForeignKey("IdClient")]
        [InverseProperty("ReservationNavigation")]
        public virtual Client ClientNavigation { get; set; }

        // Id Club
        [Column("clb_id")]
        public int IdClub;

        [ForeignKey("IdClub")]
        [InverseProperty("ReservationNavigation")]
        public virtual Club ClubNavigation { get; set; }//navigation dans club à faire

        // Date Calendrier
        [Column("cld_date")]
        public int DateCal { get; set; }

        [ForeignKey("DateCal")]
        [InverseProperty("ReservationNavigation")]
        public virtual Calendrier CalendrierNavigation { get; set; }


        [Column("rsv_datereservation", TypeName = "date")]
        public DateTime DateReservation { get; set; }

        [Column("rsv_montant")]
        public decimal Montant { get; set; }

        [InverseProperty("ParticiperReservationNavigation")]
        public virtual ICollection<Participer> ReservationParticiperNavigation { get; set;} = new List<Participer>();

        [InverseProperty("TransportNavigation")]
        public virtual ICollection<Deplacer> DeplacerTransport { get; set; } = new List<Deplacer>();

        [InverseProperty("ReservationChambreNaviguation")] 
        public virtual DesirReserve ReservationChambre { get; set; } = null!;
    }
}
