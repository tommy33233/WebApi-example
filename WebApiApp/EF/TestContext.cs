using System.Data.Entity;
using WebApiApp.Models;

namespace WebApiApp.EF
{
    public class TestContext:DbContext
    {
        public DbSet<Country> Countries { get; set; }
    }
}