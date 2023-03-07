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
        public virtual Avis AvisNavigation { get; set; } = new Avis();

        [ForeignKey("IdTypeSignalement")]
        [InverseProperty("SignalementNavigation")]
        public virtual TypeSignalement TypeSignalementNavigation { get; set; } = new TypeSignalement();

        public override bool Equals(object? obj)
        {
            return obj is Signalement signalement &&
                   IdSignalement == signalement.IdSignalement &&
                   IdClient == signalement.IdClient &&
                   IdClub == signalement.IdClub &&
                   IdAvis == signalement.IdAvis &&
                   IdTypeSignalement == signalement.IdTypeSignalement &&
                   DescriptionSignalement == signalement.DescriptionSignalement &&
                   EqualityComparer<Client>.Default.Equals(ClientNavigation, signalement.ClientNavigation) &&
                   EqualityComparer<Club>.Default.Equals(ClubNavigation, signalement.ClubNavigation) &&
                   EqualityComparer<Avis>.Default.Equals(AvisNavigation, signalement.AvisNavigation) &&
                   EqualityComparer<TypeSignalement>.Default.Equals(TypeSignalementNavigation, signalement.TypeSignalementNavigation);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(IdSignalement);
            hash.Add(IdClient);
            hash.Add(IdClub);
            hash.Add(IdAvis);
            hash.Add(IdTypeSignalement);
            hash.Add(DescriptionSignalement);
            hash.Add(ClientNavigation);
            hash.Add(ClubNavigation);
            hash.Add(AvisNavigation);
            hash.Add(TypeSignalementNavigation);
            return hash.ToHashCode();
        }

        //=======================================
    }


}
