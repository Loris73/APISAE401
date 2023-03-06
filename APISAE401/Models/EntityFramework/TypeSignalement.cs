using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_e_tsi_typesignalement")]
    public partial class TypeSignalement
    {

        public TypeSignalement() 
        {
            SignalementTypeSignalement = new HashSet<Signalement>();
        
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("tsi_id")]
        public int IdTypeSignalement { get; set; }

        [Required]
        [StringLength(255)]
        [Column("tsi_titretype")]
        public string? TitreTypeSignalement { get; set; }



        [InverseProperty("TypeSignalementSignalement")]
        public virtual ICollection<Signalement> SignalementTypeSignalement { get; set; } = null!;
    }


}

