using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_j_participer_pte")]
    public partial class Participer
    {
        [Column("pte_idparticipant")]
        public int IdParticipant { get; set; }

        [Column("rsv_idreservation")]
        public int IdReservation { get; set; }

        [ForeignKey("IdParticipant")]
        [InverseProperty("ParticiperNavigation")]
        public virtual Participant ParticipantNavigation { get; set; } = null!;

        [ForeignKey("IdReservation")]
        [InverseProperty("ParticiperNavigation")]
        public virtual Reservation ReservationNavigation { get; set; } = null!;
    }
}
