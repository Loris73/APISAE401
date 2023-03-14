using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Net.Sockets;


namespace APISAE401.Models.EntityFramework
{
    [Table("t_e_client_clt")]
    [Index(nameof(MailClient), IsUnique = true)]
    [Index(nameof(LoginClient), IsUnique = true)]
    public partial class Client
    {
        // Clé primaire
        [Key]
        [Column("clt_id")]
        public int IdClient { get; set; }

        [Column("fk_tpc_idtypeclient")]
        public int IdTypeClient { get; set; }

        // Genre du Client
        [Column("clt_genre", TypeName = "varchar")]
        public string? GenreClient { get; set; }

        // Nom du Client        
        [Column("clt_nom", TypeName = "varchar")]
        public string? NomClient { get; set; }

        // Prenom du Client
        [Column("clt_prenom", TypeName = "varchar")]
        public string? PrenomClient { get; set; }

        // Date de Naissance du Client
        [Column("clt_datenaissance", TypeName = "date")]
        [Required]
        public DateTime DateNaissanceClient { get; set; }

        // Mail du Client
        [Column("clt_mail")]
        [EmailAddress]
        [StringLength(255, MinimumLength = 6, ErrorMessage = "La longueur d’un email doit être comprise entre 6 et 100 caractères.")]
        public string? MailClient { get; set; }

        // Numero de Telephone du Client
        [Column("clt_tel", TypeName = "varchar")]
        [MaxLength(10)]
        public string? TelClient { get; set; }

        // Adresse(rue) du Client
        [Column("clt_numeroadresse")]
        public int? NumeroAdresseClient { get; set; }

        // Adresse(rue) du Client
        [Column("clt_adresse", TypeName = "varchar")]
        
        public string? AdresseClient { get; set; }

        // Code Postal du Client
        [Column("clt_cp")]
        public string? CodePostalClient { get; set; }

        // Ville du Client
        [Column("clt_ville", TypeName = "varchar")]
        public string? VilleClient { get; set; }

        // Pays du Client
        [Column("clt_pays", TypeName = "varchar")]
        [StringLength(50)]
        public string? PaysClient { get; set; }

        // Login du Client
        [Column("clt_login", TypeName = "varchar")]
        public string? LoginClient { get; set; }

        // Mot de Passe du Client
        [Column("clt_pwd", TypeName = "varchar")]
        [Required]
        public string? PasswordClient { get; set; }

        // Clé étrangère : IdTypeClient
        [ForeignKey("IdTypeClient")]
        [InverseProperty("ClientNavigation")]
        public virtual TypeClient TypeclientNavigation { get; set; }


        //==========================================================================================================

        /*----Matheo---- => 
         * InverseProperty permettant de Recuperer l'IdClient dans la table Reservation
         * Modifié le 07/03/2023
         */

        [InverseProperty("ClientNavigation")]
        public virtual ICollection<Reservation> ReservationNavigation { get; set; } = new List<Reservation>();


        [InverseProperty("ClientNavigation")]
        public virtual ICollection<Avi> AviNavigation { get; set; } = new List<Avi>();


        [InverseProperty("ClientNavigation")]
        public virtual ICollection<Detient> DetientNavigation { get; set; } = new List<Detient>();

        [InverseProperty("ClientNavigation")]
        public virtual ICollection<Signalement> SignalementNavigation { get; set; } = new List<Signalement>();

        //==========================================================================================================

        /*----Jules---- => 
         * InverseProperty permettant de Recuperer l'IdClient dans la table Reponse
         * Modifié le 07/03/2023
         */
        [InverseProperty("ClientNavigation")]
        public virtual ICollection<Reponse> ReponseNavigation { get; set; } = new List<Reponse>();

        //----------------------------------------------  

        //==========================================================================================================
    }
}
