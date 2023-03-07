using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_e_trancheage_tra")]
    public partial class TrancheAge
    {
        


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("tra_id")]
        public int IdTrancheAge { get; set; }

        [Required]
        [StringLength(255)]
        [Column("tra_detailTrancheAge")]
        public string? DetailTrancheAge { get; set; }



        [InverseProperty("TrancheAgeNavigation")]
        public virtual ICollection<Activite> ActiviteNavigation { get; set; } = new List<Activite>();

        public override bool Equals(object? obj)
        {
            return obj is TrancheAge age &&
                   IdTrancheAge == age.IdTrancheAge &&
                   DetailTrancheAge == age.DetailTrancheAge &&
                   EqualityComparer<ICollection<Activite>>.Default.Equals(ActiviteNavigation, age.ActiviteNavigation);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(IdTrancheAge, DetailTrancheAge, ActiviteNavigation);
        }
    }
}
