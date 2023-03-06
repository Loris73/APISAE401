using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_e_sig_signalement")]
    public partial class Signalement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("IdClient")]
        [Column("cli_id")]
        public int IdClient { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("IdClub")]
        [Column("clu_id")]
        public int IdClub { get; set; }

        [Key]
        [ForeignKey("IdAvis")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("avi_id")]
        public int IdAvis { get; set; }

        [Key]
        [ForeignKey("IdTypeSignalement")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("tsi_id")]
        public int IdTypeSignalement { get; set; }


        [Key]
        [Column("sig_id")]
        public int IdSignalement { get; set; }

        [Required]
        [Column("sig_description")]
        public string? DescriptionSignalement { get; set; }


        [InverseProperty("SignalementAvis")]
        public virtual Avis AvisSignalement { get; set; } = null!;

        [InverseProperty("SignalementTypeSignalement")]
        public virtual TypeSignalement TypeSignalementSignalement{ get; set;} = null!;

    }


}
