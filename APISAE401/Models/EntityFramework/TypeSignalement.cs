using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_e_typesignalement_tsi")]
    public partial class TypeSignalement
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("tsi_id")]
        public int IdTypeSignalement { get; set; }

        [Required]
        [StringLength(255)]
        [Column("tsi_titretype")]
        public string? TitreTypeSignalement { get; set; }

        [InverseProperty("TypesignalementNavigation")]
        public virtual ICollection<Signalement> SignalementNavigation { get; set; } = new List<Signalement>();
    }
}

