﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace kanban.Models
{
    public class KanbanDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
    }
}