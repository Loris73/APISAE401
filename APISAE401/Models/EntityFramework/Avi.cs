using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_e_avi_avi")]

    public partial class Avi
    {
        [Key]
        [Column("clt_id")]
        public int IdClient { get; set; }

        [Key]
        [Column("clu_id")]
        public int IdClub { get; set;}

        [Key]
        [Column("avi_id")]
        public int IdAvi { get; set; }

        [Required]
        [StringLength(255)]
        [Column("avi_titre")]
        public string titreAvi { get; set;}

        [Required]
        [Column("avi_note")]
        public int noteAvi { get; set; }

        [Column("avi_commentaire")]
        public string commentaireAvi { get; set; }


        //=======================================
        //ForeignKeys => IdClient, IdClub

        [ForeignKey("IdClient")]
        [InverseProperty("AviNavigation")]
        public virtual Client ClientNavigation { get; set; } = new Client();

        [ForeignKey("IdClub")]
        [InverseProperty("AviNavigation")]
        public virtual Club ClubNavigation { get; set; } = new Club();

       
        //=======================================

        /*----Jules---- => 
         * InverseProperty permettant de Recuperer l'IdAvis dans la table Reponse
         * Modifié le 07/03/2023
         */
        [InverseProperty("AviNavigation")]
        public virtual ICollection<Reponse> ReponseNavigation { get; set; } = new List<Reponse>();

        //----------------------------------------------

        /*----Lucas---- => 
         * InverseProperty permettant de Recuperer l'IdAvis dans la table Signalement
         * Modifié le 07/03/2023
         */

        [InverseProperty("AviNavigation")]
        public virtual ICollection<Signalement> SignalementNavigation { get; set; } = new List<Signalement>();
        //=======================================
    }
    //----------------------------------------------
}
