using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_e_activiteincluse_aci") ]
    public partial class ActiviteIncluse
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("act_id")]
        public int IdActivite { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("aci_id")]
        public int IdActiviteIncluse { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("IdTrancheAge")]
        [Column("aci_idtrancheage")]
        public int IdTrancheAge { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("IdTypeActivite")]
        [Column("aci_idtypeactivite")]
        public int IdTypeActivite { get; set; }

        [Required]
        [StringLength(255)]
        [Column("aci_titre")]
        public string? TitreActivite { get; set; }

        [Required]
        [StringLength(255)]
        [Column("aci_duree")]
        public string? DureeActivite { get; set; }

        [Required]
        [Column("aci_description")]
        public string? DescriptionActivite { get; set; }

        [Required]
        [Column("aci_ageminactivite")]
        public int? AgeMinActivite { get; set; }

        [Required]
        [StringLength(255)]
        [Column("aci_frequenceactivite")]
        public string? FrequenceActivite { get; set; }

        [InverseProperty("ActiviteIncluseActivite")]
        public virtual Activite ActiviteActiviteIncluse { get; set; } = null!;




    }
}
