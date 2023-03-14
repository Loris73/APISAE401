using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_e_typeclub_tcb")]
    [Index(nameof(IdTypeClub), IsUnique = true)]

    public partial class TypeClub
    {
        [Key]
        [Column("tcb_id")]
        public int IdTypeClub { get; set; }

        [Required]
        [Column("tcb_nom")]
        public string NomTypeClub { get; set; }

        [InverseProperty("TypeclubNavigation")]
        public virtual ICollection<Disposer> DisposerNavigation { get; set; } = new List<Disposer>();

    }
}
