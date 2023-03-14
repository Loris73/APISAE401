using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_j_comptabiliser_cpt")]
    public class Comptabiliser
    {
        [Key]
        [Column("clb_id")]
        public int IdClub { get; set; }

        [Key]
        [Column("tpc_id")]
        public int IdTypeChambre { get; set; }

        [Required]
        [Column("cpt_nbchambre")]
        public int NbChambre { get; set; }

        [ForeignKey("IdClub")]
        [InverseProperty("ComptabiliserNavigation")]
        public virtual Club ClubNavigation { get; set; } = null!;

        [ForeignKey("IdTypeChambre")]
        [InverseProperty("ComptabiliserNavigation")]
        public virtual TypeChambre TypechambreNavigation { get; set; } = null!;
    }
}
