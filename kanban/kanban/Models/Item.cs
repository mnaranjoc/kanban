﻿using System;
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

        [Display(Name = "Critical")]
        public Boolean Critical { get; set; }

        public virtual Column Column { get; set; }

        public string daysElapsed()
        {
            string ret = "";

            int days = (int)Math.Round((DateTime.Now - DateCreated).TotalDays);

            if (days < 0)
            {
                ret = "#ERROR";
            }
            else
            {
                if (days == 0)
                    ret = "created today";
                else if (days == 1)
                    ret = String.Format("created {0} day ago", days);
                else
                    ret = String.Format("created {0} days ago", days);
            }

            return ret;
        }

        public string shortDescription()
        {
            if (Description.Length >= 35)
            {
                return String.Format("{0}...", Description.Substring(0, 35));
            }
            else
            {
                return Description;
            }
        }
    }
}