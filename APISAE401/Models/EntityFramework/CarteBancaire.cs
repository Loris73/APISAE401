using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Net.Sockets;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_e_cartebancaire_cc")]
    public partial class CarteBancaire
    {
        [Key]
        [Column("cc_idcartebancaire")]
        public int IdCarteBancaire { get; set; }

        [Column("cc_numerocb", TypeName = "char")]
        [StringLength(23)]
        public string? NumeroCB { get; set;}

        [Column("cc_dateexpirationcb")]
        public string DateExpirationCB { get; set; }

        [InverseProperty("CartebancaireNavigation")]
        public virtual ICollection<Detient> DetientNavigation { get; set; } = new List<Detient>();
    }
}
