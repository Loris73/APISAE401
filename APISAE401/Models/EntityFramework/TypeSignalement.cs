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

        [InverseProperty("TypeSignalementNavigation")]
        public virtual ICollection<Signalement> SignalementNavigation { get; set; } = new List<Signalement>();

        public override bool Equals(object? obj)
        {
            return obj is TypeSignalement signalement &&
                   IdTypeSignalement == signalement.IdTypeSignalement &&
                   TitreTypeSignalement == signalement.TitreTypeSignalement &&
                   EqualityComparer<ICollection<Signalement>>.Default.Equals(SignalementNavigation, signalement.SignalementNavigation);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(IdTypeSignalement, TitreTypeSignalement, SignalementNavigation);
        }
    }


}

