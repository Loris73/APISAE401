using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace APISAE401.Models.EntityFramework
{
    [Table("t_e_typeclient_tpc")]
    [Index(nameof(IntituleTypeClient), IsUnique = true)]
    public partial class TypeClient
    {
        [Key]
        [Column("tpc_idtypeclient")]
        public int IdTypeClient { get; set; }

        [Column("tpc_intituletypeclient", TypeName = "varchar")]
        public string? IntituleTypeClient { get; set; }

        [InverseProperty("TypeclientNavigation")]
        public virtual ICollection<Client> ClientNavigation { get; set; } = new List<Client>();
    }
}

