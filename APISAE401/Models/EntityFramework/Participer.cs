using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_j_participer_pte")]
    public partial class Participer
    {
        [Key]
        [Column("pte_id")]
        public int IdParticipant { get; set; }

        [Key]
        [Column("rsv_id")]
        public int IdReservation { get; set; }

        [ForeignKey("IdParticipant")]
        [InverseProperty("ParticiperNavigation")]
        public virtual Participant ParticipantNavigation { get; set; } = null!;

        [ForeignKey("IdReservation")]
        [InverseProperty("ParticiperNavigation")]
        public virtual Reservation ReservationNavigation { get; set; } = null!;
    }
}
