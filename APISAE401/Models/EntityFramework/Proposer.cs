using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_j_proposer_pro")]
    public partial class Proposer
    {
        [Key]
        [ForeignKey("IdClub")]
        [Column("clb_id")]
        public int IdClub { get; set; }


        [Key]
        [ForeignKey("IdActivite")]
        [Column("act_id")]
        public int IdActivite { get; set; }

        [InverseProperty("ProposerClub")]
        public virtual Club ClubProposer { get; set; } = null!;


        [InverseProperty("ProposerActivite")]
        public virtual Activite ActiviteProposer { get; set; } = null!;

    }
}
