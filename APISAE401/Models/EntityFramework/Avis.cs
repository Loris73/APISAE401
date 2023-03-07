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

        //----------------------------------------------

        /*----Lucas---- => 
         * InverseProperty permettant de Recuperer l'IdAvis dans la table Signalement
         * Modifié le 07/03/2023
         */

        [InverseProperty("AvisNavigation")]
        public virtual ICollection<Signalement> SignalementNavigation { get; set; } = new List<Signalement>();

        public override bool Equals(object? obj)
        {
            return obj is Avis avis &&
                   IdClient == avis.IdClient &&
                   IdClub == avis.IdClub &&
                   IdAvis == avis.IdAvis &&
                   titreAvis == avis.titreAvis &&
                   noteAvis == avis.noteAvis &&
                   commentaireAvis == avis.commentaireAvis &&
                   EqualityComparer<Client>.Default.Equals(ClientNavigation, avis.ClientNavigation) &&
                   EqualityComparer<Club>.Default.Equals(ClubNavigation, avis.ClubNavigation) &&
                   EqualityComparer<ICollection<Reponse>>.Default.Equals(ReponsesNavigation, avis.ReponsesNavigation) &&
                   EqualityComparer<ICollection<Signalement>>.Default.Equals(SignalementNavigation, avis.SignalementNavigation);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(IdClient);
            hash.Add(IdClub);
            hash.Add(IdAvis);
            hash.Add(titreAvis);
            hash.Add(noteAvis);
            hash.Add(commentaireAvis);
            hash.Add(ClientNavigation);
            hash.Add(ClubNavigation);
            hash.Add(ReponsesNavigation);
            hash.Add(SignalementNavigation);
            return hash.ToHashCode();
        }

        //=======================================

        //----------------------------------------------
    }
}
