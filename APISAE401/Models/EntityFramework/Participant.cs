using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Net.Sockets;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_e_participant_ptca")]
    public partial class Participant
    {
        [Key]
        [Column("ptca_idparticipant")]
        public int IdParticipant { get; set; }

        // Genre du Participant
        [Column("ptca_genre", TypeName = "varchar")]
        [StringLength(255)]
        public string? GenreParticipant { get; set; }

        // Nom du Participant        
        [Column("ptca_nom", TypeName = "varchar")]
        [StringLength(255)]
        public string? NomParticipant { get; set; }

        // Prenom du Participant
        [Column("ptca_prenom", TypeName = "varchar")]
        [StringLength(255)]
        public string? PrenomParticipant { get; set; }

        // Date de Naissance du Participant
        [Column("ptca_datenaissance", TypeName = "date")]
        [Required]
        public DateTime DateNaissanceParticipant { get; set; }



        [InverseProperty("ParticipantNaviguation")]
        public virtual ICollection<Participer> ParticiperNavigation { get; set; } = new List<Participer>();

    }
}
