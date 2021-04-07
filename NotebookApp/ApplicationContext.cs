using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookApp
{
    class ApplicationContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }

        public ApplicationContext() : base("DefaultConnection") { }
    }
}
