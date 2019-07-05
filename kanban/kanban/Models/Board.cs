using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace kanban.Models
{
    public class Board
    {
        public int ID { get; set; }

        [Display(Name = "Name")]
        [Required]
        public string Description { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}