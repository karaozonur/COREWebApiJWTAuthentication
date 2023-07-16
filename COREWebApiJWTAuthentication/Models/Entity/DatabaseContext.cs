using Microsoft.EntityFrameworkCore;

namespace COREWebApiJWTAuthentication.Models.Entity
{
	public class DatabaseContext: DbContext
	{
		//https://www.c-sharpcorner.com/article/how-to-implement-jwt-authentication-in-web-api-using-net-6-0-asp-net-core/

		public DatabaseContext()
		{

		}
		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { 
		}

		public virtual DbSet<Employee>? Employees { get; set; }
		public virtual DbSet<UserInfo>? UserInfo { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<UserInfo>(entity =>
			{
				entity.HasNoKey();
				entity.ToTable("UserInfo");
				entity.Property(e => e.UserID).HasColumnName("UserID");
				entity.Property(e => e.UserName).HasMaxLength(60).IsUnicode(false);
				entity.Property(e => e.UsereEmail).HasMaxLength(30).IsUnicode(false);
				entity.Property(e => e.Password).HasMaxLength(30).IsUnicode(false);
				entity.Property(e => e.createdDate).IsUnicode(false);
			});
			modelBuilder.Entity<Employee>(entity =>
			{
				entity.HasNoKey();
				entity.ToTable("Employee");
				entity.Property(e => e.EmployeeID).HasColumnName("EmployeeID");
				entity.Property(e => e.JobTitle).HasMaxLength(60).IsUnicode(false);
				entity.Property(e => e.EmployeeName).HasMaxLength(30).IsUnicode(false);
				entity.Property(e => e.EmployeeDepertment).HasMaxLength(30).IsUnicode(false);
				entity.Property(e => e.createDate).IsUnicode(false);
			});
			base.OnModelCreating(modelBuilder);
		}

		//partial void OnModelCreating(ModelBuilder modelBuilder);
	}
}
