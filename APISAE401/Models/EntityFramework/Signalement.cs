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


        //=======================================
        //ForeignKeys => IdClient, IdClub, IdAvis, IdTypeSignalement

        [ForeignKey("IdClient")]
        [InverseProperty("SignalementNavigation")]
        public virtual Client ClientNavigation { get; set; } = new Client();

        [ForeignKey("IdClub")]
        [InverseProperty("SignalementNavigation")]
        public virtual Club ClubNavigation { get; set; } = new Club();

        [ForeignKey("IdAvis")]
        [InverseProperty("SignalementNavigation")]
        public virtual Avi AviNavigation { get; set; } = new Avi();

        [ForeignKey("IdTypeSignalement")]
        [InverseProperty("SignalementNavigation")]
        public virtual TypeSignalement TypeSignalementNavigation { get; set; } = new TypeSignalement();

        //=======================================
    }


}
