using BykeSellingOnlinePlatefrom.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BykeSellingOnlinePlatefrom.Appdata
{
    public class VRoomDbContext : IdentityDbContext<IdentityUser>
    {
        public VRoomDbContext(DbContextOptions<VRoomDbContext> options) : base(options)
        {

        }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Application_User> ApplicationUsers { get; set; }
    }
}
