using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_e_bar_bar")]
    [Index(nameof(IdBar), IsUnique = true)]

    public partial class Bar
    {
        [Key]
        [Column("bar_id")]
        public int IdBar { get; set; }

        [Key]
        [Column("bar_idclub")]
        public int IdClub { get; set; }

        [Required]
        [Column("bar_nom")]
        [StringLength(255)]
        public string NomBar { get; set; }

        [Required]
        [Column("bar_descritpion")]
        public string DescriptionBar { get; set; }

        [InverseProperty("BarNav")]
        public virtual ICollection<Bar> NavigationBar { get; set; } = new List<Bar>();
    }
}
