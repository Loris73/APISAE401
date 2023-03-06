﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APISAE401.Models.EntityFramework
{
    
        [Table("t_e_typechambre_tpc")]
        

        public partial class TypeChambre
        {
            [Key]
            [Column("tpc_id")]
            public int TypeChambreId { get; set; }

            [Required]
            [Column("tpc_nom")]
            [StringLength(255)]
            public string? TypeChambreNom { get; set; }

            [Required]
            [Column("tpc_dimension")]
            [StringLength(255)]
            public string? TypeChambreDimension { get; set; }

            [Required]
            [Column("tpc_capacite")]
            public int TypeChambreCapacite { get; set; }

            [Required]
            [Column("tpc_description")]
            [StringLength(255)]
            public string? TypeChambreDescription { get; set; }


            [InverseProperty("UtilisateurNaviguation")]
            public virtual ICollection<Notation> NotationUtilisateur { get; set; } = new List<Notation>();

            public override bool Equals(object? obj)
            {
                return obj is Utilisateur utilisateur &&
                       UtilisateurId == utilisateur.UtilisateurId &&
                       Nom == utilisateur.Nom &&
                       Prenom == utilisateur.Prenom &&
                       Mobile == utilisateur.Mobile &&
                       Mail == utilisateur.Mail &&
                       Pwd == utilisateur.Pwd &&
                       Rue == utilisateur.Rue &&
                       CodePostal == utilisateur.CodePostal &&
                       Ville == utilisateur.Ville &&
                       Pays == utilisateur.Pays &&
                       Latitude == utilisateur.Latitude &&
                       Longitude == utilisateur.Longitude;
            }

            public override int GetHashCode()
            {
                HashCode hash = new HashCode();
                hash.Add(UtilisateurId);
                hash.Add(Nom);
                hash.Add(Prenom);
                hash.Add(Mobile);
                hash.Add(Mail);
                hash.Add(Pwd);
                hash.Add(Rue);
                hash.Add(CodePostal);
                hash.Add(Ville);
                hash.Add(Pays);
                hash.Add(Latitude);
                hash.Add(Longitude);
                return hash.ToHashCode();
            }
        }
    
}
