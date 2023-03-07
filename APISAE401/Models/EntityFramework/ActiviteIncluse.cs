using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_e_activiteincluse_aci") ]
    public partial class ActiviteIncluse
    {
        
        [Key]
        [Column("act_id")]
        public int IdActivite { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("aci_id")]
        public int IdActiviteIncluse { get; set; }

       
    
        [Column("aci_idtrancheage")]
        public int IdTrancheAge { get; set; }

        
      
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

        [ForeignKey("IdActivite")]
        [InverseProperty("ActiviteIncluseNavigation")]
        public virtual Activite ActiviteNavigation { get; set; } = new Activite();




    }
}
