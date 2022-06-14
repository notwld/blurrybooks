using BlurryBooks.Models;
using Microsoft.EntityFrameworkCore;

namespace BlurryBooks.Data
{
    public class ApplicationDbContext :DbContext
    {   
        //Microsoft Entity Framework Core will manages database
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
                
        }
        //Table Creation
        public DbSet<Category> Categories { get; set; } 
    }
}
