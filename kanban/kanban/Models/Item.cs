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

        [Display(Name = "Descripción")]
        [Required]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha creación")]
        public DateTime DateCreated { get; set; }

        [Display(Name = "Columna")]
        public int Column { get; set; }

    }
}