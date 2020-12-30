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
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;
using DevExpress.Persistent.BaseImpl.EF.Kpi;
using System.Data.SQLite;

namespace AmaraProject.WasteManager.Module.BusinessObjects
{
    public class WasteManagerContextInitializer : DbContextTypesInfoInitializerBase
    {
        protected override DbContext CreateDbContext()
        {
            //DbContextInfo contextInfo = new DbContextInfo(typeof(WasteManagerDbContext), new DbProviderInfo(providerInvariantName: "System.Data.SQLite.EF6", providerManifestToken: "2008"));

            //DbContextInfo contextInfo = new DbContextInfo(typeof(WasteManagerDbContext), new DbProviderInfo(providerInvariantName: "System.Data.SQLite.EF6", providerManifestToken: "3"));

            DbContextInfo contextInfo = new DbContextInfo(typeof(WasteManagerDbContext), new DbProviderInfo(providerInvariantName: "System.Data.SQLite", providerManifestToken: "3"));

            return contextInfo.CreateInstance();
        }
    }


    [TypesInfoInitializer(typeof(WasteManagerContextInitializer))]
    public class WasteManagerDbContext : DbContext
    {
        //public WasteManagerDbContext(String connectionString = "ConnectionString")
        //    : base(connectionString)
        //{
        //}

        public WasteManagerDbContext(string connectionString = "ConnectionString")
           : base(new SQLiteConnection() { ConnectionString = connectionString }, true)
        {
        }


        public WasteManagerDbContext(DbConnection connection)
            : base(connection, false)
        {
        }

        public WasteManagerDbContext(ObjectContext objectContext) : base(objectContext, false)
        {
        }


        public WasteManagerDbContext() : base("ConnectionString")
        {
        }


        public DbSet<ModuleInfo> ModulesInfo { get; set; }
        public DbSet<PermissionPolicyRole> Roles { get; set; }
        public DbSet<PermissionPolicyTypePermissionObject> TypePermissionObjects { get; set; }
        public DbSet<PermissionPolicyUser> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<FileData> FileData { get; set; }
        public DbSet<DashboardData> DashboardData { get; set; }
        public DbSet<Analysis> Analysis { get; set; }
        public DbSet<HCategory> HCategories { get; set; }
        public DbSet<KpiDefinition> KpiDefinition { get; set; }
        public DbSet<KpiInstance> KpiInstance { get; set; }
        public DbSet<KpiHistoryItem> KpiHistoryItem { get; set; }
        public DbSet<KpiScorecard> KpiScorecard { get; set; }
        public DbSet<ReportDataV2> ReportDataV2 { get; set; }
        public DbSet<ModelDifference> ModelDifferences { get; set; }
        public DbSet<ModelDifferenceAspect> ModelDifferenceAspects { get; set; }


        public DbSet<Bank> Banks { get; set; }
        public DbSet<WasteCategory> WasteCategories { get; set; }
        public DbSet<WasteItem> WasteItems { get; set; }
        public DbSet<WasteBuyer> WasteBuyers { get; set; }
        public DbSet<WasteSeller> WasteSellers { get; set; }
        public DbSet<WasteListing> WasteListings { get; set; }
        public DbSet<ListingItem> ListingItems { get; set; }
        public DbSet<SalesInvoice> SalesInvoices { get; set; }

    }
}