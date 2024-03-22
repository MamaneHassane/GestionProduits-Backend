using Microsoft.EntityFrameworkCore;
using TP_SOMEI.Entities;

namespace TP_SOMEI.Datas;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products => Set<Product>();
}