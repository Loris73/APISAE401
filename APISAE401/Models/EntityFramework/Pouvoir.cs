using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_j_pouvoir_pou")]
    public partial class Pouvoir
    {
        [Column("rsv_idreservation")]
        public int IdReservation { get; set; }


        [Column("act_id")]
        public int IdActivite { get; set; }


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
        public virtual ActiviteALaCarte ActivitealacarteNavigation { get; set; } = new ActiviteALaCarte();

        //=======================================

    }
}
