using DomainAbstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    [Table("students")]
    public class Student:DbEntity
    {
        [Column("firstName")]
        [MaxLength(128)]
        [Required]
        public string FirstName { get; set; }
        [Column("lastName")]
        [MaxLength(128)]
        [Required]
        public string LastName { get; set; }
        [Column("middleName")]
        [MaxLength(128)]
        public string MiddleName { get; set; }

        [Column("groupId")]
        public int GroupId { get; set; }
        public Group Group { get; set; }
        
    }
}
