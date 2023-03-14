using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_e_activite_act")]
    public class Activite
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("act_id")]
        public int IdActivite { get; set; }


        [Column("tra_id")]
        public int? IdTrancheAge { get; set; }


        [Column("tat_id")]
        public int IdTypeActivite { get; set; }

        [Required]
        [Column("act_titre")]
        public string TitreActivite { get; set; }

        [Required]
        [Column("act_duree")]
        public string DureeActivite { get; set; }

        [Required]
        [Column("act_description")]
        public string DescriptionActivite { get; set; }

        [Required]
        [Column("act_agemin")]
        public int AgeMinActivite { get; set; }


        [Column("act_frequence")]
        public string? FrequenceActivite { get; set; }


        //=======================================
        //ForeignKeys => IdTrancheAge,IDTypeActivite,Proposer

        [ForeignKey("IdTrancheAge")]
        [InverseProperty("ActiviteNavigation")]
        public virtual TrancheAge TrancheageNavigation { get; set; } = new TrancheAge();

        [ForeignKey("IdTypeActivite")]
        [InverseProperty("ActiviteNavigation")]
        public virtual TypeActivite TypeactiviteNavigation { get; set; } = new TypeActivite();

        //=======================================
        //InverseProperty => IdTrancheAge,IDTypeActivite,Proposer

        [InverseProperty("ActiviteNavigation")]
        public virtual ICollection<Proposer> ProposerNavigation { get; set; } = new List<Proposer>();

        [InverseProperty("ActiviteNavigation")]
        public virtual ICollection<Pouvoir> PouvoirNavigation { get; set; } = new List<Pouvoir>();
    }
}

