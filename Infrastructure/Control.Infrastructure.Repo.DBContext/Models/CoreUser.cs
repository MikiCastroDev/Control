using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Control.Infrastructure.Repo.DBContext.Models
{
    [Table("core.users")]
    public partial class CoreUser
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; } = null!;
        [StringLength(45)]
        public string Email { get; set; } = null!;
        [Column("FKRole")]
        public Guid Fkrole { get; set; }
        [Column(TypeName = "timestamp")]
        public DateTime CreatedAt { get; set; }
        [StringLength(255)]
        public string CreatedBy { get; set; } = null!;
        [Column(TypeName = "timestamp")]
        public DateTime? ModifiedAt { get; set; }
        [StringLength(255)]
        public string? ModifiedBy { get; set; }
        [Column(TypeName = "timestamp")]
        public DateTime? EnabledAt { get; set; }
        [StringLength(255)]
        public string? EnabledBy { get; set; }
    }
}
