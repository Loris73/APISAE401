using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_e_calendrier_cal")]
    public partial class Calendrier
    {
        // Clé primaire
        [Key]
        [Column("cld_date", TypeName = "date")]
        [Required]
        public DateTime DateCal { get; set; }


        [InverseProperty("CalendrierNavigation")]
        public virtual Tarif TarifNavigation { get; set; } = null!;

        [InverseProperty("CalendrierNavigation")]
        public virtual ICollection<Reservation> Navigation { get; set; } = new List<Reservation>();
    }
}
