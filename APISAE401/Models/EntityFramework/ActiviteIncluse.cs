using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_e_activiteincluse_aci") ]
    public partial class ActiviteIncluse
    {
        
        [Key]
        [Column("act_id")]
        public int IdActivite { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("aci_id")]
        public int IdActiviteIncluse { get; set; }

       
    
        [Column("aci_idtrancheage")]
        public int IdTrancheAge { get; set; }

        
      
        [Column("aci_idtypeactivite")]
        public int IdTypeActivite { get; set; }

        [Required]
        [StringLength(255)]
        [Column("aci_titre")]
        public string? TitreActivite { get; set; }

        [Required]
        [StringLength(255)]
        [Column("aci_duree")]
        public string? DureeActivite { get; set; }

        [Required]
        [Column("aci_description")]
        public string? DescriptionActivite { get; set; }

        [Required]
        [Column("aci_ageminactivite")]
        public int? AgeMinActivite { get; set; }

        [Required]
        [StringLength(255)]
        [Column("aci_frequenceactivite")]
        public string? FrequenceActivite { get; set; }

        [ForeignKey("IdActivite")]
        [InverseProperty("ActiviteIncluseNavigation")]
        public virtual Activite ActiviteNavigation { get; set; } = new Activite();

        public override bool Equals(object? obj)
        {
            return obj is ActiviteIncluse incluse &&
                   IdActivite == incluse.IdActivite &&
                   IdActiviteIncluse == incluse.IdActiviteIncluse &&
                   IdTrancheAge == incluse.IdTrancheAge &&
                   IdTypeActivite == incluse.IdTypeActivite &&
                   TitreActivite == incluse.TitreActivite &&
                   DureeActivite == incluse.DureeActivite &&
                   DescriptionActivite == incluse.DescriptionActivite &&
                   AgeMinActivite == incluse.AgeMinActivite &&
                   FrequenceActivite == incluse.FrequenceActivite &&
                   EqualityComparer<Activite>.Default.Equals(ActiviteNavigation, incluse.ActiviteNavigation);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(IdActivite);
            hash.Add(IdActiviteIncluse);
            hash.Add(IdTrancheAge);
            hash.Add(IdTypeActivite);
            hash.Add(TitreActivite);
            hash.Add(DureeActivite);
            hash.Add(DescriptionActivite);
            hash.Add(AgeMinActivite);
            hash.Add(FrequenceActivite);
            hash.Add(ActiviteNavigation);
            return hash.ToHashCode();
        }
    }
}
