using DomainAbstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("faculties")]
    public class Faculty:DbEntity
    {
        [Column("name")]
        [MaxLength(32)]
        public string Name { get; set; }
        public List<Group> Groups { get; set; }
    }
}
