using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_e_activitealacarte")]
    public class ActiviteALaCarte
    {


        [Key]
        [Column("act_id")]
        public int IdActivite { get; set; }

        [Key]
        [Column("alc_id")]
        public int IdActiviteALaCarte { get; set; }

        [Column("alc_id")]
        public int IdTrancheAge { get; set; }


        [Column("alc_id")]
        public int IdTypeActivite { get; set; }

        [Required]
        [StringLength(255)]
        [Column("alc_titre")]
        public string? TitreActivite { get; set; }

        [Required]
        [StringLength(255)]
        [Column("alc_duree")]
        public string? DureeActivite { get; set; }

        [Required]
        [Column("alc_description")]
        public string? DescriptionActivite { get; set; }

        [Required]
        [Column("alc_ageminactivite")]
        public int? AgeMinActivite { get; set; }

        [Required]
        [StringLength(255)]
        [Column("alc_frequenceactivite")]
        public string? FrequenceActivite { get; set; }

        [Required]
        [Column("alc_prixminactivite")]
        public int? PrixMinActivite { get; set; }

        //=======================================
        //ForeignKeys => IdActivite

        [ForeignKey("IdActivite")]
        [InverseProperty("ActiviteALaCarteNavigation")]
        public virtual Activite ActiviteNavigation { get; set; } = new Activite();


        //=======================================


        [InverseProperty("PouvoirNavigation")]
        public virtual ICollection<Pouvoir> PouvoirNavigation { get; set; } = new List<Pouvoir>();

        public override bool Equals(object? obj)
        {
            return obj is ActiviteALaCarte carte &&
                   IdActivite == carte.IdActivite &&
                   IdActiviteALaCarte == carte.IdActiviteALaCarte &&
                   IdTrancheAge == carte.IdTrancheAge &&
                   IdTypeActivite == carte.IdTypeActivite &&
                   TitreActivite == carte.TitreActivite &&
                   DureeActivite == carte.DureeActivite &&
                   DescriptionActivite == carte.DescriptionActivite &&
                   AgeMinActivite == carte.AgeMinActivite &&
                   FrequenceActivite == carte.FrequenceActivite &&
                   PrixMinActivite == carte.PrixMinActivite &&
                   EqualityComparer<Activite>.Default.Equals(ActiviteNavigation, carte.ActiviteNavigation) &&
                   EqualityComparer<ICollection<Pouvoir>>.Default.Equals(PouvoirNavigation, carte.PouvoirNavigation);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(IdActivite);
            hash.Add(IdActiviteALaCarte);
            hash.Add(IdTrancheAge);
            hash.Add(IdTypeActivite);
            hash.Add(TitreActivite);
            hash.Add(DureeActivite);
            hash.Add(DescriptionActivite);
            hash.Add(AgeMinActivite);
            hash.Add(FrequenceActivite);
            hash.Add(PrixMinActivite);
            hash.Add(ActiviteNavigation);
            hash.Add(PouvoirNavigation);
            return hash.ToHashCode();
        }
    }
}