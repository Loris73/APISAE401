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

        // Id Club
        [Column("clb_id")]
        public int IdClub { get; set; }

        // Id Client
        [Column("clt_id")]
        public int IdClient { get; set; }         

        // Date Calendrier
        [Column("cld_datedebut")]
        public int DateDebutCalendrier { get; set; }

        [Column("cld_datefin")]
        public int DateFinCalendrier { get; set; }

        [Column("rsv_datereservation", TypeName = "date")]
        public DateTime DateReservation { get; set; }

        [Column("rsv_montant")]
        public decimal Montant { get; set; }

        [ForeignKey("IdClub")]
        [InverseProperty("ReservationNavigation")]
        public virtual Club ClubNavigation { get; set; }//navigation dans club à faire

        [ForeignKey("IdClient")]
        [InverseProperty("ReservationNavigation")]
        public virtual Client ClientNavigation { get; set; }

        [ForeignKey("DateDebutCalendrier")]
        [InverseProperty("ReservationdatedebutNavigation")]
        public virtual Calendrier CalendrierdebutNavigation { get; set; }   

        [ForeignKey("DateFinCalendrier")]
        [InverseProperty("ReservationdatefinNavigation")]
        public virtual Calendrier CalendrierfinNavigation { get; set; }       

        [InverseProperty("ReservationNavigation")]
        public virtual ICollection<Participer> ParticiperNavigation { get; set;} = new List<Participer>();

        [InverseProperty("ReservationNavigation")]
        public virtual ICollection<Deplacer> DeplacerNavigation { get; set; } = new List<Deplacer>();

        [InverseProperty("ReservationNavigation")]
        public virtual ICollection<Pouvoir> PouvoirNavigation { get; set; } = new List<Pouvoir>();

        [InverseProperty("ReservationNavigation")] 
        public virtual DesirReserve DesirereserveNavigation { get; set; } = new DesirReserve();
    }
}
