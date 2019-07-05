using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace kanban.Models
{
    public class KanbanDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Column> Columns { get; set; }

        public System.Data.Entity.DbSet<kanban.Models.Board> Boards { get; set; }
    }
}