using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Frameworks_ThatSneakerShop.Models;

namespace Frameworks_ThatSneakerShop.Data {
    public class ApplicationDbContext : IdentityDbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Frameworks_ThatSneakerShop.Models.Category> Category { get; set; }
        public DbSet<Frameworks_ThatSneakerShop.Models.Payment> Payment { get; set; }
        public DbSet<Frameworks_ThatSneakerShop.Models.Shoe> Shoe { get; set; }
        public DbSet<Frameworks_ThatSneakerShop.Models.Whislist> Whislist { get; set; }
    }
}