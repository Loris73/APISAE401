using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_e_transport_tsp")]
    public partial class Transport
    {
        [Key]
        [Column("tsp_id")]
        public int IdTransport { get; set; }

        [Required]
        [Column("tpc_nom")]
        [StringLength(255)]
        public string? TransportNom { get; set; }

        [InverseProperty("TransportNaviguation")]
        public virtual ICollection<Deplacer> DeplacerTransport { get; set; } = new List<Deplacer>();

    }
}
