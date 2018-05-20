using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CSharpBits.Domain.Model.Configuration
{
    [Table("ConfigurationTableName")]
    public class Configuration
    {
        private List<string> _Tags;
        [Key]
        [Column("KeyColumnName")]
        public string Key { get; set; }
        public string Value { get; set; }
        public string Tags { get; set; }
        [NotMapped]
        public List<string> TagList
        {
            get
            {
                return _Tags;
            }
            set
            {
                _Tags =
                      Value.Contains("#") ? Value.Split('#').ToList()
                    : Value.Contains(",") ? Value.Split(',').ToList()
                    : Value.Contains("|") ? Value.Split('|').ToList()
                    : Value.Contains("_") ? Value.Split('_').ToList()
                    : Value.Contains("-") ? Value.Split('-').ToList()
                    : Value.Contains(";") ? Value.Split(';').ToList()
                    : new List<string> { Value };
            }
        }
    }
}
