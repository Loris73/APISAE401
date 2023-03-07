using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APISAE401.Models.EntityFramework
{
    [System.ComponentModel.DataAnnotations.Schema.Table("t_j_pou_pouvoir")]
    public partial class Pouvoir
    {
        [Key]
        [ForeignKey("IdReservation")]
        [Column("rsv_idreservation")]
        public int IdReservation { get; set; }

        [Key]
        [Column("act_id")]
        [ForeignKey("IdActivite")]
        public int IdActivite { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("alc_id")]
        public int IdActiviteALaCarte { get; set; }

        [InverseProperty("PouvoirReservation")]
        public virtual Reservation ReservationPouvoir { get; set; } = null!;

        [InverseProperty("PouvoirActiviteALaCarte")]
        public virtual ActiviteALaCarte ActiviteALaCartePouvoir { get; set; } = null!;

    }
}
