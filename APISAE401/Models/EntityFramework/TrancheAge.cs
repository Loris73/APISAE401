using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_e_tra_trancheage")]
    public partial class TrancheAge
    {
        
        public TrancheAge()
        {
            ActiviteTrancheAge = new HashSet<Activite>();

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("tra_id")]
        public int IdTrancheAge { get; set; }

        [Required]
        [StringLength(255)]
        [Column("tra_detailTrancheAge")]
        public string? DetailTrancheAge { get; set; }



        [InverseProperty("TrancheAgeActivite")]
        public virtual ICollection<Activite> ActiviteTrancheAge { get; set; } = null!;
    }
}
