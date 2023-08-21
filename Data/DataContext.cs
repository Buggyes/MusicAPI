using Microsoft.EntityFrameworkCore;

using MusicAPI.Models;

namespace MusicAPI.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options) { }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			optionsBuilder.UseSqlServer("server=DESKTOP-QHFSSE2\\MSSQLSERVER01;database=musicdb;trusted_connection=true;TrustServerCertificate=True");
		}
		public DbSet<MusicModel> Songs { get; set; }
	}
}
