using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_j_pouvoir_pou")]
    public partial class Pouvoir
    {
        [Key]
        [Column("rsv_id")]
        public int IdReservation { get; set; }

        [Key]
        [Column("act_id")]
        public int IdActivite { get; set; }

        [Column("pou_prixmin")]
        public double PrixMin { get; set;}


        [ForeignKey("IdReservation")]
        [InverseProperty("PouvoirNavigation")]
        public virtual Reservation ReservationNavigation { get; set; } = new Reservation();

        [ForeignKey("IdActivite")]
        [InverseProperty("PouvoirNavigation")]
        public virtual Activite ActiviteNavigation { get; set; } = new Activite();

        //=======================================

    }
}
