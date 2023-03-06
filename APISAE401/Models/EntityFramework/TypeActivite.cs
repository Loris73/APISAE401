using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_e_typeactivite_tat")]
    [Index(nameof(IdTypeActivite), IsUnique = true)]

    public partial class TypeActivite
    {
        [Key]
        [Column("tat_id")]
        public int IdTypeActivite { get; set; }

        [Required]
        [Column("tat_nom")]
        [StringLength(255)]
        public string NomTypeActivite { get; set; }

        [Required]
        [Column("tat_description")]
        public string DescriptionTypeActivite { get; set; }
    }
}
