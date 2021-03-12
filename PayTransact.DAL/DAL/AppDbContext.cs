using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PayTransact.Models.Models;
using PayTransact.Utilities.Globals;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayTransact.Persistence.DAL
{
	public class AppDbContext : IdentityDbContext<ApplicationUser>
	{
		public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
		{}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			string ADMIN_ID = "D15B65B9-7702-4AD8-882F-93BDB8D19500";
			string ROLE_ID = "36E00FD4-F329-40EA-AD28-2C326721A9BD";

			builder.Entity<IdentityRole>().HasData(new IdentityRole
			{
				Id = ROLE_ID,
				Name = StaticConstants.AdminRole,
				NormalizedName = StaticConstants.AdminRole,
				ConcurrencyStamp = ROLE_ID
			});

			var appUser = new ApplicationUser
			{
				Id = ADMIN_ID,
				Email = "kodexkenth@gmail.com",
				EmailConfirmed = false,
				FirstName = "Super",
				LastName = "Admin",
				UserName = "kodexkenth@gmail.com",
				NormalizedEmail = "kodexkenth@gmail.com",
				NormalizedUserName = "kodexkenth@gmail.com"
			};

			PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
			appUser.PasswordHash = passwordHasher.HashPassword(appUser, "@Digital21");

			builder.Entity<ApplicationUser>().HasData(appUser);

			builder.Entity<IdentityUserRole<string>>()
				.HasData(new IdentityUserRole<string>
				{
					RoleId = ROLE_ID,
					UserId = ADMIN_ID
				});

			base.OnModelCreating(builder);  
		}
		public DbSet<ApplicationUser> AppUsers { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Transaction> Transactions { get; set; }
		public DbSet<IdentityUserClaim<string>> IdentityUserClaims { get; set; }
	}
}
