using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace EFTest.Models
{
	public class EFTestDbContext : DbContext
	{
		public DbSet<Prefecture> Prefectures { get; set; }

		public DbSet<Municipality> Municipalities { get; set; }
	}
}