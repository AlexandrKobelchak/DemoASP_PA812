using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainAbstractions
{
    public interface IDbEntity
    {
        [Key]
        [Column("id")]
        int Id { get; set; }
    }
}
