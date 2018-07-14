
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Data.Domen
{
    [Table("Users")]
    public class Users:BaseEntity
    { 
       
        [Column("Email")]
        [Required]
        public string Email { get; set; }

        [Column("Password")]
        [Required]
        [MinLength(5)]
        [MaxLength(15)]
        public string Password { get; set; }

        [Column("Name")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

      
    }
}