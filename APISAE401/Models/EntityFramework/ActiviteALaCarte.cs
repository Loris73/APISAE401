using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_e_alc_activitealacarte")]
    public class ActiviteALaCarte
    {

        public ActiviteALaCarte()
        {
            PouvoirActiviteALaCarte = new HashSet<Pouvoir>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("act_id")]
        public int IdActivite { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("alc_id")]
        public int IdActiviteALaCarte { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("IdTrancheAge")]
        [Column("alc_id")]
        public int IdTrancheAge { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("IdTypeActivite")]
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

        [InverseProperty("ActiviteALaCarteActivite")]
        public virtual Activite ActiviteActiviteALacarte { get; set; } = null!;

        [InverseProperty("ActiviteALaCartePouvoir")]
        public virtual ICollection<Pouvoir> PouvoirActiviteALaCarte { get; set; } = null!; 
    }
}
