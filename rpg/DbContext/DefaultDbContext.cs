using Microsoft.EntityFrameworkCore;
using rpg.Models;

namespace Rpg.DbContext;

public class DefaultDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DefaultDbContext(DbContextOptions<DefaultDbContext> option) : base(option)
    {
        
    }

    public DbSet<Character> Characters => Set<Character>();
}