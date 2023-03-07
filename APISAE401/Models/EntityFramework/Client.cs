﻿using Microsoft.EntityFrameworkCore;
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

        // Genre du Client
        [Column("clt_genre", TypeName = "varchar")]
        [StringLength(255)]
        public string? GenreClient { get; set; }

        // Nom du Client        
        [Column("clt_nom", TypeName = "varchar")]
        [StringLength(255)]
        public string? NomClient { get; set; }

        // Prenom du Client
        [Column("clt_prenom", TypeName = "varchar")]
        [StringLength(255)]
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

        // Addresse(rue) du Client
        [Column("clt_adresse", TypeName = "varchar")]
        [StringLength(255)]
        public string? AdresseClient { get; set; }

        // Code Postal du Client
        [Column("clt_cp", TypeName = "char")]
        [StringLength(5)]
        public string? CodePostalClient { get; set; }

        // Ville du Client
        [Column("clt_ville", TypeName = "varchar")]
        [StringLength(255)]
        public string? VilleCleint { get; set; }

        // Pays du Client
        [Column("clt_pays", TypeName = "varchar")]
        [StringLength(50)]
        public string? PaysClient { get; set; }

        // Login du Client
        [Column("clt_login", TypeName = "varchar")]
        [StringLength(255)]
        public string? LoginClient { get; set; }

        // Mot de Passe du Client
        [Column("clt_pwd", TypeName = "varchar")]
        [StringLength(255)]
        [Required]
        public string? PasswordClient { get; set; }

        // Clé étrangère : IdTypeClient
        [Column("tpc_idtypeclient")]
        public int IdTypeClient { get; set; }

        [ForeignKey("IdTypeClient")]
        [InverseProperty("TypeClientClientNavigation")]
        public virtual TypeClient ClientTypeClientNavigation { get; set; }


        //==========================================================================================================

        /*----Matheo---- => 
         * InverseProperty permettant de Recuperer l'IdClient dans la table Reservation
         * Modifié le 07/03/2023
         */

        [InverseProperty("ReservationClientNavigation")]
        public virtual ICollection<Reservation> ClientReservationNavigation { get; set; } = new List<Reservation>();

        //==========================================================================================================

        /*----Matheo---- => 
         * InverseProperty permettant de Recuperer l'IdClient dans la table Reservation
         * Modifié le 07/03/2023
         */

        [InverseProperty("AvisClientNavigation")]
        public virtual ICollection<Avis> ClientAvisNavigation { get; set; } = new List<Avis>();
        
        //==========================================================================================================

        /*----Matheo---- => 
         * InverseProperty permettant de Recuperer l'IdClient dans la table Detient
         * Modifié le 07/03/2023
         */

        [InverseProperty("CarteBancaireClientNavigation")]
        public virtual Detient ClientDetientNavigation { get; set; }
        
        //==========================================================================================================

        /*----Jules---- => 
         * InverseProperty permettant de Recuperer l'IdClient dans la table Reponse
         * Modifié le 07/03/2023
         */
        [InverseProperty("ClientReponsesNavigation")]
        public virtual ICollection<Reponse> ReponsesClientNavigation { get; set; } = new List<Reponse>();

        //----------------------------------------------  

        //==========================================================================================================

        public override bool Equals(object? obj)
        {
            return obj is Client client &&
                   IdClient == client.IdClient &&
                   GenreClient == client.GenreClient &&
                   NomClient == client.NomClient &&
                   PrenomClient == client.PrenomClient &&
                   DateNaissanceClient == client.DateNaissanceClient &&
                   MailClient == client.MailClient &&
                   TelClient == client.TelClient &&
                   AdresseClient == client.AdresseClient &&
                   CodePostalClient == client.CodePostalClient &&
                   VilleCleint == client.VilleCleint &&
                   PaysClient == client.PaysClient &&
                   LoginClient == client.LoginClient &&
                   PasswordClient == client.PasswordClient;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(IdClient);
            hash.Add(GenreClient);
            hash.Add(NomClient);
            hash.Add(PrenomClient);
            hash.Add(DateNaissanceClient);
            hash.Add(MailClient);
            hash.Add(TelClient);
            hash.Add(AdresseClient);
            hash.Add(CodePostalClient);
            hash.Add(VilleCleint);
            hash.Add(PaysClient);
            hash.Add(LoginClient);
            hash.Add(PasswordClient);
            return hash.ToHashCode();
        }
    }
}
