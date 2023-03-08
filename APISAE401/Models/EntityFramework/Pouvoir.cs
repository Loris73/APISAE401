using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_j_pouvoir_pou")]
    public partial class Pouvoir
    {
        [Key]
        [Column("rsv_idreservation")]
        public int IdReservation { get; set; }

        [Key]
        [Column("act_id")]
        public int IdActivite { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("alc_id")]
        public int IdActiviteALaCarte { get; set; }



        [ForeignKey("IdReservation")]
        [InverseProperty("PouvoirNavigation")]
        public virtual Reservation ReservationNavigation { get; set; } = new Reservation();

        [ForeignKey("IdActivite")]
        [InverseProperty("PouvoirNavigation")]
        public virtual Activite ActiviteNavigation { get; set; } = new Activite();

        [ForeignKey("IdActiviteALaCarte")]
        [InverseProperty("PouvoirNavigation")]
        public virtual ActiviteALaCarte ActiviteALaCarteNavigation { get; set; } = new ActiviteALaCarte();

        public override bool Equals(object? obj)
        {
            return obj is Pouvoir pouvoir &&
                   IdReservation == pouvoir.IdReservation &&
                   IdActivite == pouvoir.IdActivite &&
                   IdActiviteALaCarte == pouvoir.IdActiviteALaCarte &&
                   EqualityComparer<Reservation>.Default.Equals(ReservationNavigation, pouvoir.ReservationNavigation) &&
                   EqualityComparer<Activite>.Default.Equals(ActiviteNavigation, pouvoir.ActiviteNavigation) &&
                   EqualityComparer<ActiviteALaCarte>.Default.Equals(ActiviteALaCarteNavigation, pouvoir.ActiviteALaCarteNavigation);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(IdReservation, IdActivite, IdActiviteALaCarte, ReservationNavigation, ActiviteNavigation, ActiviteALaCarteNavigation);
        }
        //=======================================

    }
}
