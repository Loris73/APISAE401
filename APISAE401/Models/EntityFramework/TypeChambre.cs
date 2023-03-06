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
        public virtual ICollection<APourPf> APourTypeChambre { get; set; } = new List<APourPf>();

        [InverseProperty("ServiceCommoditesNaviguation")]
        public virtual ICollection<AvoirComme> AvoirCommeServiceCommodites { get; set; } = new List<AvoirComme>();

        [InverseProperty("TypeChambreTarif")]
        public virtual TypeChambre TarifChambre { get; set; }


        public override bool Equals(object? obj)
        {
            return obj is TypeChambre chambre &&
                   TypeChambreId == chambre.TypeChambreId &&
                   TypeChambreNom == chambre.TypeChambreNom &&
                   TypeChambreDimension == chambre.TypeChambreDimension &&
                   TypeChambreCapacite == chambre.TypeChambreCapacite &&
                   TypeChambreDescription == chambre.TypeChambreDescription &&
                   EqualityComparer<ICollection<APourPf>>.Default.Equals(APourTypeChambre, chambre.APourTypeChambre);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(TypeChambreId, TypeChambreNom, TypeChambreDimension, TypeChambreCapacite, TypeChambreDescription, APourTypeChambre);
        }
    }
}