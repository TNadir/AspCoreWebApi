using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Data.Domen
{
    [Table("Events")]
    public class Events : BaseEntity
    {
        [Column("Type")]
        [Required]
        [MaxLength(15)]
        public string Type { get; set; }

        [Column("Amount")]
        [Required]
        public decimal Amount { get; set; }


        [Column("Date")]
        [Required]
        public DateTime Date { get; set; }

        [Column("Description")]
        [Required]
        [MaxLength(250)]
        public string Description { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Categories Category { get; set; }
    }
}