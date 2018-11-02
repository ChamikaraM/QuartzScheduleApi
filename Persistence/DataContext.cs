using Microsoft.EntityFrameworkCore;
using QuartzScheduleApi.Models;

namespace QuartzScheduleApi.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<QrtzJobDetail> qrtzJobDetails { get; set; }
    }
}
