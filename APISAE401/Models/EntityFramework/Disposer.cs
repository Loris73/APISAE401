using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_j_deposer_dps")]
    [Index(nameof(IdClub), IsUnique = true)]
    [Index(nameof(IdTypeClub), IsUnique = true)]

    public partial class Disposer
    {
        [Key]
        [Column("dps_idclub")]
        public int IdClub { get; set; }

        [Key]
        [Column("dps_idtypeclub")]
        public int IdTypeClub { get; set; }


        [InverseProperty("ClubNav")]
        public virtual ICollection<Club> NavigationClub { get; set; } = new List<Club>();
        
        [InverseProperty("TypeClubNav")]
        public virtual ICollection<TypeClub> NavigationTypeClub { get; set; } = new List<TypeClub>();
    }
}
