﻿using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_e_club_clb")]
    [Index(nameof(IdClub), IsUnique = true)]

    public partial class Club
    {
        [Key]
        [Column("clb_id")]
        public int IdClub { get; set; }

        [Key]
        [Column("clb_id_domaine_skiable")]
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
        

        
        [InverseProperty("ClubTarif")]
        public virtual PointFort TarifClub { get; set; };
    }
}