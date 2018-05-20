using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSharpBits.Domain.Model.EntityGroup
{
    [Table("SomeEntityGroupModelTableName")]
    public class SomeEntityGroupModel
    {
        [Key]
        [Column("SomeEntityGroupModelIdColumnName")]
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdated { get; set; }
        public string LastUpdatedBy { get; set; }
        public bool Deleted { get; set; }
        public DateTime DeletedDateTime { get; set; }
        public string DeletedBy { get; set; }
    }
}
