using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;



namespace APISAE401.Models.EntityFramework
{
    public class PointFort
    {
        [Table("t_e_pointfort_ptf")]


        public partial class TypeChambre
        {
            [Key]
            [Column("ptf_id")]
            public int PointFortId { get; set; }

            [Required]
            [Column("ptf_nom")]
            [StringLength(255)]
            public string? PointFortNom { get; set; }

            [InverseProperty("PointFortNaviguation")]
            public virtual ICollection<APourPf> NotationUtilisateur { get; set; } = new List<APourPf>();

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
}
