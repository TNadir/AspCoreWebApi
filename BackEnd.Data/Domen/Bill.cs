using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Data.Domen
{
    [Table("Bill")]
    public class Bill:BaseEntity
    {
        [Column("Value")]
        [Required]
        public decimal Value { get; set; }

        [Column("Currency")]
        [Required]
        public string Currency { get; set; }
    }
}