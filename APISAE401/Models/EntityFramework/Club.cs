using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace APISAE401.Models.EntityFramework
{
    /*----Jules---- => 
    * Model Club
    * Modifié le 07/03/2023 par Jules
    */

    [Table("t_e_club_clb")]
    [Index(nameof(IdClub), IsUnique = true)]

    public partial class Club
    {
        [Key]
        [Column("clb_id")]
        public int IdClub { get; set; }

        [Required]
        [Column("clb_nom")]
        [StringLength(50)]
        public string NomClub { get; set; }

        [Required]
        [Column("clb_latitude")]
        [MaxLength(10)]
        public double LongitudeLocalisationClub { get; set; }

        [Required]
        [Column("clb_longitude")]
        [MaxLength(10)]
        public double LatitudeLocalisationClub { get; set; }

        [Required]
        [Column("clb_description")]
        public string DescriptionClub { get; set; }

        [Required]
        [Column("clb_adresse")]
        [StringLength(255)]
        public string AdresseClub { get; set; }

        [Required]
        [Column("clb_tel")]
        [StringLength(10)]
        public string TelClub { get; set; }

        [Required]
        [Column("clb_mail")]
        [EmailAddress]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "La longueur d’un email doit être comprise entre 6 et 100 caractères.")]
        public string MailClub { get; set; }

        //InverseProperties => IdClub

        /*----------------------------------Mathéo------------------------------------- =>  
         * InverseProperty permettant de recuperer l'IdClub dans la table Reponse
         * Modifié le 07/03/2023
         */
        [InverseProperty("ClubNavigation")]
        public virtual ICollection<Tarif> TarifNavigation { get; set; } = new List<Tarif>();

        [InverseProperty("ClubNavigation")]
        public virtual ICollection<Reservation> ReservationNavigation { get; set; } = new List<Reservation>();

        [InverseProperty("ClubNavigation")]
        public virtual ICollection<Disposer> DisposerNavigation { get; set; } = new List<Disposer>();

        [InverseProperty("ClubNavigation")]
        public virtual ICollection<Regrouper> RegrouperNavigation { get; set; } = new List<Regrouper>();
        //-------------------------------------------------------------------------------   


        /*----------------------------------Jules------------------------------------- => 
         * InverseProperty par Jules
         * Modifié le 08/03/2023
         */
        // InverseProperty permettant de recuperer l'IdClub dans la table Reponse
        [InverseProperty("ClubNavigation")]
        public virtual ICollection<Reponse> ReponseNavigation { get; set; } = new List<Reponse>();

        // InverseProperty permettant de recuperer l'IdClub dans la table Bar
        [InverseProperty("ClubNavigation")]
        public virtual ICollection<Bar> BarNavigation { get; set; } = new List<Bar>();

        // InverseProperty permettant de recuperer l'IdClub dans la table Restaurant 
        [InverseProperty("ClubNavigation")]
        public virtual ICollection<Restaurant> RestaurantNavigation { get; set; } = new List<Restaurant>();

        // InverseProperty permettant de recuperer l'IdClub dans la table Photo
        [InverseProperty("ClubNavigation")]
        public virtual ICollection<Photo> PhotoNavigation { get; set; } = new List<Photo>();

        // InverseProperty permettant de recuperer l'IdClub dans la table Proposer
        [InverseProperty("ClubNavigation")]
        public virtual ICollection<Proposer> ProposerNavigation { get; set; } = new List<Proposer>();

        // InverseProperty permettant de recuperer l'IdClub dans la table APourLoc
        [InverseProperty("ClubNavigation")]
        public virtual ICollection<APourSousLoc> ApoursouslocNavigation { get; set; } = new List<APourSousLoc>();

        // InverseProperty permettant de recuperer l'IdClub dans la table Avi
        [InverseProperty("ClubNavigation")]
        public virtual ICollection<Avi> AviNavigation { get; set; } = new List<Avi>();

        // InverseProperty permettant de recuperer l'IdClub dans la table Appartient
        [InverseProperty("ClubNavigation")]
        public virtual ICollection<Appartient> AppartientNavigation { get; set; } = new List<Appartient>();
        //-------------------------------------------------------------------------------   


        /*----------------------------------Loris------------------------------------- =>  
         * Modifié le 07/03/2023
         */
        [InverseProperty("ClubNavigation")]
        public virtual Comptabiliser ComptabiliserNavigation { get; set; } = null!;

        //-------------------------------------------------------------------------------
        //=========================================================================================================================
    }
}