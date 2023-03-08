using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace APISAE401.Models.EntityFramework
{
    /*----Jules---- => 
    * Model Commodites
    * Modifié le 07/03/2023 par Jules
    */
    [Table("t_e_domaineskiable_skb")]
    [Index(nameof(IdDomaineSkiable), IsUnique = true)]

    public partial class DomaineSkiable
    {
        //=========PROPERTIES=============
        [Key]
        [Column("skb_id")]
        public int IdDomaineSkiable { get; set; }

        [Required]
        [Column("skb_titre")]
        [StringLength(50)]
        public string TitreDomaineSkiable { get; set; }

        [Required]
        [Column("skb_nom")]
        [StringLength(50)]
        public string NomDomaineSkiable { get; set; }

        [Required]
        [Column("skb_altitude")]
        [StringLength(50)]
        public string AltitudeDomaineSkiable { get; set; }

        [Required]
        [Column("skb_longueurpiste")]
        [StringLength(50)]
        public double longueurPisteDomaineSkiable { get; set; }

        [Required]
        [StringLength(3)]
        [Column("skb_nbpistes")]
        public string nbPistesDomaineSkiable { get; set; }

        [Required]
        [Column("skb_descritpion")]
        public string descriptionDomaineSkiable { get; set; }
        //=======================================

        //=======================================
        /*----Jules---- => 
         * InverseProperty permettant de Recuperer l'IdDomaineSkiable dans le model Club
         * Modifié le 07/03/2023
         */
        [InverseProperty("DomaineskiableNavigation")]
        public virtual ICollection<Club> ClubNavigation { get; set; } = new List<Club>();

        // InverseProperty permettant de recuperer l'IdDomaineSkiable dans la table Photo
        [InverseProperty("DomaineskiableNavigation")]
        public virtual ICollection<Photo> PhotoNavigation { get; set; } = new List<Photo>();

        // InverseProperty permettant de recuperer l'IdClub dans la table Appartient
        [InverseProperty("DomaineskiableNavigation")]
        public virtual ICollection<Appartient> AppartientNavigation { get; set; } = new List<Appartient>();

        //=======================================

    }
    //------------------------------
}