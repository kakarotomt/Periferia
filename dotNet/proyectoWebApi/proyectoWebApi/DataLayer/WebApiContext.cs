using Microsoft.EntityFrameworkCore;
using proyectoWebApi.DataLayer.Models;

namespace proyectoWebApi.DataLayer
{
    public class WebApiContext : DbContext
    {
        public WebApiContext(DbContextOptions<WebApiContext> DB) : base(DB)
        {
            
        }

        public DbSet<Product> BT_Product { get; set; }
    }
}
