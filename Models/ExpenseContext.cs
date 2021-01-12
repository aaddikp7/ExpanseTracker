using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ExpanseTracker.Models
{
    public class ExpenseContext : DbContext
    {
        public ExpenseContext (DbContextOptions<ExpenseContext> options) :base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
        
        }
        public DbSet<Expense> Expenses { get; set; }
    }

    
}
