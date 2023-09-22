using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LNTADSpreadsheets.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LNTADSpreadsheets.Models
{
	public class AppDBContext : IdentityDbContext<AppUser>	
	{
		public AppDBContext(DbContextOptions<AppDBContext> options)
			: base(options)
		{
		}

		public DbSet<SpreadsheetModel> tSpreadsheets { get; set; }
		public DbSet<ArchiveModel> tArchives { get; set; }
		public DbSet<ReportModel> tReports { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			//builder.Seed(); 

		}
	}
}
