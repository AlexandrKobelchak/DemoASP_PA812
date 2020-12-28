using DomainAbstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    [Table("groups")]
    public class Group:DbEntity
    {
        [Column("name")]
        [MaxLength(32)]
        [Required]
        public string Name { get; set; }
        
        [Column("facultyId")]
        [Required]
        public int FacultyId { get; set; }
        public Faculty Faculty { get; set; }
        public List<Student> Students { get; set; }
    }
}
