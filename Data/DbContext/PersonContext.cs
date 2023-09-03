using Microsoft.EntityFrameworkCore;
using Models;

namespace Data.DbContext  // Corrected namespace
{
    public class PersonContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<PersonModel> Persons { get; set; }

        public PersonContext(DbContextOptions<PersonContext> options) : base(options) { }
    }
}
