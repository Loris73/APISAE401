﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_e_commodites_cmd")]
    [Index(nameof(IdCommodites), IsUnique = true)]

    public partial class Commodites
    {
        [Key]
        [Column("cmd_id")]
        public int IdCommodites { get; set; }

        [Required]
        [Column("cmd_typecommodites")]
        [StringLength(255)]
        public string TypeCommodites { get; set; }

    }
}
