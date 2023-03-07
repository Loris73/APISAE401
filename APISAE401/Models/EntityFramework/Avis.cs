using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_e_avis_avi")]

    public partial class Avis
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("IdClient")]
        [Column("cli_id")]
        public int IdClient { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("IdClub")]
        [Column("clu_id")]
        public int IdClub { get; set;}

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("avi_id")]
        public int IdAvis { get; set; }

        [Required]
        [StringLength(255)]
        [Column("avi_titre")]
        public string? titreAvis { get; set;}

        [Required]
        [Column("avi_note")]
        public int? noteAvis { get; set; }

        [Column("avi_commentaire")]
        public string commentaireAvis { get; set; }

        [InverseProperty("AvisClient")]
        public virtual Client ClientAvis { get; set; } = null!;

        [InverseProperty("AvisClub")]
        public virtual Club ClubAvis { get; set; } = null!;

        [InverseProperty("AvisSignalement")]
        public virtual ICollection<Signalement> SignalementAvis { get; set; } = null!;

        [InverseProperty("AvisReponse")]
        public virtual ICollection<Signalement> ReponseAvis { get; set; } = null!;

        /*----Jules---- => 
         * InverseProperty permettant de Recuperer l'IdAvis dans la table Reponse
         * Modifié le 07/03/2023
         */

        [InverseProperty("IdAvis")]
        public virtual ICollection<Reponse> ReponsesNavigation { get; set; } = new List<Reponse>();

        //----------------------------------------------
    }
}
