using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_j_participer_ptce")]
    public partial class Participer
    {
        [Key]
        [Column("ptca_idparticipant")]
        public int IdParticipant { get; set; }

        [Key]
        [Column("rsv_idreservation")]
        public int IdReservation { get; set; }

        [ForeignKey("IdParticipant")]
        [InverseProperty("ParticiperNavigation")]
        public virtual ICollection<Participant> ParticipantNaviguation { get; set; } = new List<Participant>();

        [ForeignKey("IdReservation")]
        [InverseProperty("ParticiperNavigation")]
        public virtual Reservation ReservationNavigation { get; set; } = null!;
    }
}
