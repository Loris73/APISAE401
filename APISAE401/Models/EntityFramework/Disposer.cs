using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_j_disposer_dps")]
    [Index(nameof(IdClub), IsUnique = true)]
    [Index(nameof(IdTypeClub), IsUnique = true)]

    public partial class Disposer
    {
        [Key]
        [Column("clb_id")]
        public int IdClub { get; set; }

        [Key]
        [Column("tcp_id")]
        public int IdTypeClub { get; set; }

        [ForeignKey("IdClub")]
        [InverseProperty("DisposerNavigation")]
        public virtual ICollection<Club> ClubNavigation { get; set; } = new List<Club>();
        
        [ForeignKey("IdTypeClub")]
        [InverseProperty("DisposerNavigation")]
        public virtual ICollection<TypeClub> TypeclubNavigation { get; set; } = new List<TypeClub>();
    }
}
