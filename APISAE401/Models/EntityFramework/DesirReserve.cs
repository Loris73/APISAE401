﻿using System.ComponentModel.DataAnnotations;
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
        public int IdTypeChambre { get; set; }

        [Required]
        [Column("drv_nbparticipants", TypeName = "char") ]
        [StringLength(3)]
        public string? NbParicipants { get; set; }


        [ForeignKey("IdReservation")]
        [InverseProperty("DesirereserveNavigation")]
        public virtual Reservation ReservationNaviguation { get; set; } = null!;

        [ForeignKey("IdTypeChambre")]
        [InverseProperty("DesirereserveNavigation")]
        public virtual TypeChambre TypechambreNavigation { get; set; } = null!;

    }
}
