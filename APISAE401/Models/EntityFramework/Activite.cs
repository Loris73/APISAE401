using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_e_activite_act")]
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


        [Column("tca_id")]
        public int IdTrancheAge { get; set; }


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


        //=======================================
        //ForeignKeys => IdTrancheAge,IDTypeActivite,Proposer

        [ForeignKey("IdTrancheAge")]
        [InverseProperty("ActiviteNavigation")]
        public virtual TrancheAge TrancheAgeNavigation { get; set; } = new TrancheAge();

        [ForeignKey("IdTypeActivite")]
        [InverseProperty("ActiviteNavigation")]
        public virtual TypeActivite TypeActiviteNavigation { get; set; } = new TypeActivite();

        //=======================================

        [InverseProperty("ActiviteNavigation")]
        public virtual ICollection<ActiviteIncluse> ActiviteIncluseNavigation { get; set; } = new List<ActiviteIncluse>();

        [InverseProperty("ActiviteNavigation")]
        public virtual ICollection<ActiviteALaCarte> ActiviteALaCarteNavigation { get; set; } = new List<ActiviteALaCarte>();

        [InverseProperty("ActiviteNavigation")]
        public virtual ICollection<Proposer> ProposerNavigation { get; set; } = new List<Proposer>();
    }
}
