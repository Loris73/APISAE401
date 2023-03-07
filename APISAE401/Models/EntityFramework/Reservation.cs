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

        [Column("clt_id")]
        public int IdCleint { get; set; }

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
        [InverseProperty("")]
        public virtual Club ClubReservationNavigation { get; set; }//navigation dans club à faire

        // Date Calendrier
        [Column("cld_date")]
        public int DateCal { get; set; }

        [ForeignKey("DateCal")]
        [InverseProperty("")]
        public virtual Calendrier CalendrierReservationNavigation { get; set; }


        [Column("rsv_datereservation", TypeName = "date")]
        public DateTime DateReservation { get; set; }

        [Column("rsv_montant")]
        public decimal Montant { get; set; }

        // ForeignKey : dateCal à faire
        [InverseProperty("ReservationNavigation")]
        public virtual ICollection<Participer> ParticiperReservation { get; set;} = new List<Participer>();

        [InverseProperty("TransportNavigation")]
        public virtual ICollection<Deplacer> DeplacerTransport { get; set; } = new List<Deplacer>();

        [InverseProperty("ReservationChambreNaviguation")] 
        public virtual DesirReserve ReservationChambre { get; set; } = null!;

        public override bool Equals(object? obj)
        {
            return obj is Reservation reservation &&
                   IdReservation == reservation.IdReservation &&
                   IdCleint == reservation.IdCleint &&
                   EqualityComparer<Client>.Default.Equals(ClientReservationNavigation, reservation.ClientReservationNavigation) &&
                   DateReservation == reservation.DateReservation &&
                   Montant == reservation.Montant &&
                   EqualityComparer<ICollection<Participer>>.Default.Equals(ParticiperReservation, reservation.ParticiperReservation) &&
                   EqualityComparer<ICollection<Deplacer>>.Default.Equals(DeplacerTransport, reservation.DeplacerTransport) &&
                   EqualityComparer<DesirReserve>.Default.Equals(ReservationChambre, reservation.ReservationChambre);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(IdReservation, IdCleint, ClientReservationNavigation, DateReservation, Montant, ParticiperReservation, DeplacerTransport, ReservationChambre);
        }
    }
}
