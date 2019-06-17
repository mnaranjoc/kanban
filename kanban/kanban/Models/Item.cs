using System;
using System.ComponentModel.DataAnnotations;

namespace kanban.Models
{
    public class Item
    {
        public int ID { get; set; }

        [Display(Name = "Description")]
        [Required]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Created date")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Column")]
        public int ColumnID { get; set; }

        public virtual Column Column { get; set; }
    }
}