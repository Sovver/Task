using System;
using System.Data;
using System.Linq;
using System.Data.Entity;
using System.Data.Common;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.ComponentModel;
using DevExpress.ExpressApp.EF.Updating;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.ExpressApp.Design;
using DevExpress.ExpressApp.EF.DesignTime;

namespace Task.Module.BusinessObjects {
	public class TaskContextInitializer : DbContextTypesInfoInitializerBase {
		protected override DbContext CreateDbContext() {
			return new TaskDbContext("App=EntityFramework");
		}
	}
	[TypesInfoInitializer(typeof(TaskContextInitializer))]
	public class TaskDbContext : DbContext {
		public TaskDbContext(String connectionString)
			: base(connectionString) {
		}
		public TaskDbContext(DbConnection connection)
			: base(connection, false) {
		}
		public TaskDbContext()
			: base("name=ConnectionString") {
		}
		public DbSet<ModuleInfo> ModulesInfo { get; set; }
	}
}