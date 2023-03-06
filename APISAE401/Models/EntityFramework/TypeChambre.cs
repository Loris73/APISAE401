namespace APISAE401.Models.EntityFramework
{
    public class TypeChambre
    {
        [Table("t_e_utilisateur_utl")]
        [Index(nameof(Mail), IsUnique = true)]

        public partial class Utilisateur
        {
            [Key]
            [Column("utl_id")]
            public int UtilisateurId { get; set; }

            [Column("utl_nom")]
            [StringLength(50)]
            public string? Nom { get; set; }

            [Column("utl_prenom")]
            [StringLength(50)]
            public string? Prenom { get; set; }

            [Column("utl_mobile")]
            [MaxLength(10)]
            public string? Mobile { get; set; }

            [Required]
            [Column("utl_mail")]
            [EmailAddress]
            [StringLength(100, MinimumLength = 6, ErrorMessage = "La longueur d’un email doit être comprise entre 6 et 100 caractères.")]

            public string? Mail { get; set; }

            [Column("utl_pwd")]
            [StringLength(64)]
            [Required]
            public string? Pwd { get; set; }


            [Column("utl_rue")]
            [StringLength(200)]
            public string? Rue { get; set; }

            [Column("utl_cp")]
            [StringLength(5)]
            public string? CodePostal { get; set; }

            [Column("utl_ville")]
            [StringLength(50)]
            public string? Ville { get; set; }

            [Column("utl_pays")]
            [StringLength(50)]
            public string? Pays { get; set; } = "France";

            [Column("utl_latitude")]
            public float? Latitude { get; set; }

            [Column("utl_longitude")]
            public float? Longitude { get; set; }

            [Column("utl_datecreation", TypeName = "date")]
            [Required]
            public DateTime DateCreation { get; set; } = DateTime.Now;

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
}
