using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_e_avis_avi")]

    public partial class Avis
    {
        [Key]
        [ForeignKey("IdClient")]
        [Column("cli_id")]
        public int IdClient { get; set; }

        [Key]
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


        //=======================================
        //ForeignKeys => IdClient, IdClub

        [ForeignKey("IdClient")]
        [InverseProperty("AvisNavigation")]
        public virtual Client ClientNavigation { get; set; } = new Client();

        [ForeignKey("IdClub")]
        [InverseProperty("AvisNavigation")]
        public virtual Club ClubNavigation { get; set; } = new Club();

       
        //=======================================

        /*----Jules---- => 
         * InverseProperty permettant de Recuperer l'IdAvis dans la table Reponse
         * Modifié le 07/03/2023
         */
        [InverseProperty("AvisNavigation")]
        public virtual ICollection<Reponse> ReponsesNavigation { get; set; } = new List<Reponse>();

        // InverseProperty permettant de Recuperer l'IdAvis dans la table Signalement
        [InverseProperty("AvisNavigation")]
        public virtual ICollection<Signalement> SignalementNavigation { get; set; } = new List<Signalement>();

        //----------------------------------------------
    }
}
