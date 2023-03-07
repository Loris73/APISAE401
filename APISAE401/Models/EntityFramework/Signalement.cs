using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_e_signalement_sig")]
    public partial class Signalement
    {

        [Key]
        [Column("sig_id")]
        public int IdSignalement { get; set; }

        [ForeignKey("IdClient")]
        [Column("cli_id")]
        public int IdClient { get; set; }

        
       
        [ForeignKey("IdClub")]
        [Column("clu_id")]
        public int IdClub { get; set; }

      
        [ForeignKey("IdAvis")]
        [Column("avi_id")]
        public int IdAvis { get; set; }

        
        [ForeignKey("IdTypeSignalement")]
        [Column("tsi_id")]
        public int IdTypeSignalement { get; set; }

        [Required]
        [Column("sig_description")]
        public string? DescriptionSignalement { get; set; }


        [InverseProperty("SignalementAvis")]
        public virtual Avis AvisSignalement { get; set; } = null!;

        [InverseProperty("SignalementTypeSignalement")]
        public virtual TypeSignalement TypeSignalementSignalement{ get; set;} = null!;

    }


}
