using Microsoft.EntityFrameworkCore;

namespace Devlivery.Authentication.Data
{
    public class AuthDbContext : DbContext
    {

        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }

    }
}
