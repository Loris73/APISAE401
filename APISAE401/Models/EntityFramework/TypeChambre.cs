using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APISAE401.Models.EntityFramework
{

    [Table("t_e_typechambre_tpc")]


    public partial class TypeChambre
    {
        [Key]
        [Column("tpc_id")]
        public int TypeChambreId { get; set; }

        [Required]
        [Column("tpc_nom")]
        [StringLength(255)]
        public string? TypeChambreNom { get; set; }

        [Required]
        [Column("tpc_dimension")]
        [StringLength(255)]
        public string? TypeChambreDimension { get; set; }

        [Required]
        [Column("tpc_capacite")]
        public int TypeChambreCapacite { get; set; }

        [Required]
        [Column("tpc_description")]
        [StringLength(255)]
        public string? TypeChambreDescription { get; set; }


        [InverseProperty("TypeChambreNavigation")]
        public virtual ICollection<APourPf> ApourpfNavigation { get; set; } = new List<APourPf>();

        [InverseProperty("TypeChambreNavigation")]
        public virtual ICollection<AvoirComme> AvoircommeNavigation { get; set; } = new List<AvoirComme>();

        [InverseProperty("TypechambreNavigation")]
        public virtual ICollection<Comptabiliser> ComptabiliserNavigation { get; set; } = new List<Comptabiliser>();

        [InverseProperty("TypeChambreNavigation")]
        public virtual ICollection<Tarif> TarifNavigation { get; set; } = new List<Tarif>();

        [InverseProperty("TypeChambreNavigation")] 
        public virtual ICollection<DesirReserve> DesirereserveNavigation { get; set; } = new List<DesirReserve>();

        // InverseProperty permettant de recuperer l'IdTypeChambre dans la table Photo
        [InverseProperty("TypeChambreNavigation")]
        public virtual ICollection<Photo> PhotoNavigation { get; set; } = new List<Photo>();
    }
}