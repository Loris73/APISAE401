using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_j_desirreserver_drv")]
    public partial class DesirReserve
    {
        [Key]
        [Column("rsv_idreservation")]
        public int IdReservation { get; set; }

        [Key]
        [Column("tpc_id")]
        public int TypeChambreId { get; set; }

        [Required]
        [Column("drv_nbparticipants", TypeName = "char") ]
        [StringLength(3)]
        public string? NbParicipants { get; set; }


        [ForeignKey("IdReservation")]
        [InverseProperty("ReservationChambre")]
        public virtual Reservation ReservationChambreNaviguation { get; set; } = null!;

        [ForeignKey("TypeChambreId")]
        [InverseProperty("ChambreReserve")]
        public virtual TypeChambre ChambreReservationNavigation { get; set; } = null!;

        public override bool Equals(object? obj)
        {
            return obj is DesirReserve reserve &&
                   IdReservation == reserve.IdReservation &&
                   TypeChambreId == reserve.TypeChambreId &&
                   NbParicipants == reserve.NbParicipants &&
                   EqualityComparer<Reservation>.Default.Equals(ReservationChambreNaviguation, reserve.ReservationChambreNaviguation) &&
                   EqualityComparer<TypeChambre>.Default.Equals(ChambreReservationNavigation, reserve.ChambreReservationNavigation);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(IdReservation, TypeChambreId, NbParicipants, ReservationChambreNaviguation, ChambreReservationNavigation);
        }
    }
}
