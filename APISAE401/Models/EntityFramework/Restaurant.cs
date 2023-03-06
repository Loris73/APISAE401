using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_e_restaurant_rsn")]
    [Index(nameof(IdRestaurant), IsUnique = true)]

    public partial class Restaurant
    {
        [Key]
        [Column("rsn_id")]
        public int IdRestaurant { get; set; }

        [Key]
        [Column("rsn_idclub")]
        public int IdClub { get; set; }

        [Required]
        [Column("rsn_nom")]
        [StringLength(255)]
        public string NomRestaurant { get; set; }

        [Required]
        [Column("rsn_descritpion")]
        public string DescriptionRestaurant { get; set; }

        [InverseProperty("RestaurantNav")]
        public virtual ICollection<Restaurant> NavigationRestaurant { get; set; } = new List<Restaurant>();

        public override bool Equals(object? obj)
        {
            return obj is Restaurant restaurant &&
                   this.IdRestaurant == restaurant.IdRestaurant &&
                   this.IdClub == restaurant.IdClub &&
                   this.NomRestaurant == restaurant.NomRestaurant &&
                   this.DescriptionRestaurant == restaurant.DescriptionRestaurant &&
                   EqualityComparer<ICollection<Restaurant>>.Default.Equals(this.NavigationRestaurant, restaurant.NavigationRestaurant);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.IdRestaurant, this.IdClub, this.NomRestaurant, this.DescriptionRestaurant, this.NavigationRestaurant);
        }
    }
}
