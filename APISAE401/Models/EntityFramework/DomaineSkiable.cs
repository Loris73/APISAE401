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
        [Column("skb_altitude_domaine_skiable")]
        [StringLength(50)]
        public string AltitudeDomaineSkiable { get; set; }

        [Required]
        [Column("skb_altitude_club_domaine_skiable")]
        [StringLength(50)]
        public double AltitudeClubDomaineSkiable { get; set; }

        [Required]
        [Column("skb_longueur_piste")]
        [StringLength(50)]
        public double longueurPisteDomaineSkiable { get; set; }

        [Required]
        [Column("skb_nb_pistes")]
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
        [InverseProperty("DomaineSkiableNavigation")]
        public virtual ICollection<Club> ClubNavigation { get; set; } = new List<Club>();

        //=======================================

    }
    //------------------------------
}