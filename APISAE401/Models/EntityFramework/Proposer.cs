using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_j_proposer_pro")]
    public partial class Proposer
    {
        [Key]
        
        [Column("clb_id")]
        public int IdClub { get; set; }

        [Key]
        [Column("act_id")]
        public int IdActivite { get; set; }


        [ForeignKey("IdClub")]
        [InverseProperty("ProposerNavigation")]
        public virtual Club ClubNavigation { get; set; } = new Club();

        [ForeignKey("IdActivite")]
        [InverseProperty("ProposerNavigation")]
        public virtual Activite ActiviteNavigation { get; set; } = new Activite();

        public override bool Equals(object? obj)
        {
            return obj is Proposer proposer &&
                   IdClub == proposer.IdClub &&
                   IdActivite == proposer.IdActivite &&
                   EqualityComparer<Club>.Default.Equals(ClubNavigation, proposer.ClubNavigation) &&
                   EqualityComparer<Activite>.Default.Equals(ActiviteNavigation, proposer.ActiviteNavigation);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(IdClub, IdActivite, ClubNavigation, ActiviteNavigation);
        }
    }
}
