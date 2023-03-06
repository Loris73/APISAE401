using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_e_act_activite")]
    public class Activite
    {
        public Activite()
        {
            ActiviteIncluseActivite = new HashSet<ActiviteIncluse>();
            ActiviteALaCarteActivite = new HashSet<ActiviteALaCarte>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("act_id")]
        public int IdActivite { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("IdTrancheAge")]
        [Column("tca_id")]
        public int IdTrancheAge { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("IdTypeActivite")]
        [Column("tra_id")]
        public int IdTypeActivite { get; set; }

        [Required]
        [StringLength(255)]
        [Column("act_titre")]
        public string? TitreActivite { get; set; }

        [Required]
        [StringLength(255)]
        [Column("act_duree")]
        public string? DureeActivite { get; set; }

        [Required]
        [Column("act_description")]
        public string? DescriptionActivite { get; set; }

        [Required]
        [Column("act_ageminactivite")]
        public int? AgeMinActivite { get; set; }

        [Required]
        [StringLength(255)]
        [Column("act_frequenceactivite")]
        public string? FrequenceActivite { get; set; }


        [InverseProperty("ActiviteTypeActivite")]
        public virtual TypeActivite TypeActiviteActivite { get; set; } = null!;

        [InverseProperty("ActiviteTrancheAge")]
        public virtual TrancheAge TrancheAgeActivite { get; set; } = null!;

        [InverseProperty("ActiviteProposer")]
        public virtual Proposer ProposerActivite { get; set; } = null!;

        [InverseProperty("ActiviteActiviteIncluse")]
        public virtual ICollection<ActiviteIncluse> ActiviteIncluseActivite { get; set; } = null!;

        [InverseProperty("ActiviteActiviteALaCarte")]
        public virtual ICollection<ActiviteALaCarte> ActiviteALaCarteActivite { get; set; } = null!;


    }
}
