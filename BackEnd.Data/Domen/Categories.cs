using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Data.Domen
{
    [Table("Categories")]
    public class Categories : BaseEntity
    {
        public Categories()
        {
            this.Events=new Collection<Events>();
        }
        
        [Column("Name")]
        [Required]
        public string Name { get; set; }

        [Column("Capacity")]
        [Required]
        public int Capacity { get; set; }

        public ICollection<Events> Events { get; set; }

    }
}