using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Net.Sockets;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_e_participant_pta")]
    public partial class Participant
    {
        [Key]
        [Column("pta_idparticipant")]
        public int IdParticipant { get; set; }

        // Genre du Participant
        [Column("pta_genre", TypeName = "varchar")]
        public string? GenreParticipant { get; set; }

        // Nom du Participant        
        [Column("pta_nom", TypeName = "varchar")]
        public string? NomParticipant { get; set; }

        // Prenom du Participant
        [Column("pta_prenom", TypeName = "varchar")]
        public string? PrenomParticipant { get; set; }

        // Date de Naissance du Participant
        [Column("pta_datenaissance", TypeName = "date")]
        [Required]
        public DateTime DateNaissanceParticipant { get; set; }



        [InverseProperty("ParticipantNavigation")]
        public virtual ICollection<Participer> ParticiperNavigation { get; set; } = new List<Participer>();

    }
}
