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
        public int TypeChambreId { get; set; }

        [Required]
        [Column("cpt_nbchambre")]
        public int NbChambre { get; set; }

        [ForeignKey("IdClub")]
        [InverseProperty("ComptabiliserNav")]
        public virtual Club EstComptabilise { get; set; } = null!;

        [ForeignKey("TypeChambreId")]
        [InverseProperty("ComptabiliserTypeChambreNav")]
        public virtual ICollection<TypeChambre> TypeChambreEstComptabilise { get; set; } = new List<TypeChambre>();
    }
}
