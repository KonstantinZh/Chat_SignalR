using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace CHAT
{
	public class ApplicationContext : DbContext
	{
		public DbSet<User> Users { get; set; } = null!;
		public DbSet<Chat> Chats { get; set; } = null!;
		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
		{
			Database.EnsureCreated();
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Chat>().HasData(

			   new Chat { id = 15, Desc = "For programmers" },
			   new Chat { id = 1 , Desc = "For friends"}
	   );
		}
	}
}
