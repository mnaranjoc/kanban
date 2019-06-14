using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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
        public int Column { get; set; }

    }
}