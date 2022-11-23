using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Control.Infrastructure.Repo.DBContext.Models
{
    [Table("core.roles")]
    public partial class CoreRole
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(45)]
        public string Name { get; set; } = null!;
        [StringLength(255)]
        public string? Description { get; set; }
        [Required]
        public bool? Enabled { get; set; }
    }
}
