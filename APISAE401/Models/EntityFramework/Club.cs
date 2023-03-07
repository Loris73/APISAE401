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

        [Key]
        [Column("clb_iddomaineskiable")]
        public int IdDomaineSkiable { get; set; }

        [Required]
        [Column("clb_nom")]
        [StringLength(50)]
        public string NomClub { get; set; }

        [Required]
        [Column("clb_latitude_localisation")]
        [MaxLength(10)]
        public double LongitudeLocalisationClub { get; set; }

        [Required]
        [Column("clb_longitude_localisation")]
        [MaxLength(10)]
        public double LatitudeLocalisationClub { get; set; }

        [Required]
        [Column("clb_description")]
        public string DescritpionClub { get; set; }

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

        [Required]
        [Column("clb_documentation")]
        public string DocumentationClub { get; set; }

        //=======================================
        //ForeignKey => IdDomaineSkiable 

        /*----Jules---- => 
         * InverseProperty permettant de Recuperer l'IdDomaineSkiable dans le model Club
         * Modifié le 07/03/2023
         */
        [ForeignKey("IdDomaineSkiable")]
        [InverseProperty("ClubNavigation")]
        public virtual DomaineSkiable DomaineSkiableNavigation { get; set; } = null!;

        //---------------------------------------------

        //=========================================================================================================================
        //InverseProperties => IdClub

        /*----------------------------------Mathéo------------------------------------- =>  
         * InverseProperty permettant de recuperer l'IdClub dans la table Reponse
         * Modifié le 07/03/2023
         */
        [InverseProperty("ClubTarif")]
        public virtual PointFort TarifClub { get; set; }
        //-------------------------------------------------------------------------------   


        /*----------------------------------Jules------------------------------------- => 
         * InverseProperty par Jules
         * Modifié le 07/03/2023
         */
        // InverseProperty permettant de recuperer l'IdClub dans la table Reponse
        [InverseProperty("ClubReponsesNavigation")]
        public virtual ICollection<Reponse> ReponsesClubNavigation { get; set; } = new List<Reponse>();

        // InverseProperty permettant de recuperer l'IdClub dans la table Bar
        [InverseProperty("ClubBarNavigation")]
        public virtual ICollection<Bar> BarClubNavigation { get; set; } = new List<Bar>();

        // InverseProperty permettant de recuperer l'IdClub dans la table Restaurant 
        [InverseProperty("ClubRestaurantNavigation")]
        public virtual ICollection<Restaurant> RestaurantClubNavigation { get; set; } = new List<Restaurant>();
        //-------------------------------------------------------------------------------   


        /*----------------------------------Loris------------------------------------- =>  
         * Modifié le 07/03/2023
         */
        [InverseProperty("EstComptabilise")]
        public virtual Comptabiliser ComptabiliserNav { get; set; } = null!;

        [InverseProperty("LocNav")]
        public virtual Club APourClub { get; set; } = null!;

        //-------------------------------------------------------------------------------
        //=========================================================================================================================
    }
}