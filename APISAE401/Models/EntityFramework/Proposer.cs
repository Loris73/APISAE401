using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_j_proposer_pro")]
    public partial class Proposer
    {
        [Column("clb_id")]
        public int IdClub { get; set; }

        [Column("act_id")]
        public int IdActivite { get; set; }

        //=======================================

        //=======================================
        // ForeignKeys => IdClub, IdActivite
        [ForeignKey("IdClub")]
        [InverseProperty("ProposerNavigation")]
        public virtual Club ClubNavigation { get; set; } = new Club();

        [ForeignKey("IdActivite")]
        [InverseProperty("ProposerNavigation")]
        public virtual Activite ActiviteNavigation { get; set; } = new Activite();
        //=======================================

        //=======================================
        // InverseProperty => IdBar, IdTypeActivite, IdRestaurant, IdDomaineSkiable, IdClub, IdTypeChambre


        //=======================================

    }
}
