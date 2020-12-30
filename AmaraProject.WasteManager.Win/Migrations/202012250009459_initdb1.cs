namespace AmaraProject.WasteManager.Win.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdb1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Analyses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 2147483647),
                        Criteria = c.String(maxLength: 2147483647),
                        ObjectTypeName = c.String(maxLength: 2147483647),
                        DimensionPropertiesString = c.String(maxLength: 2147483647),
                        PivotGridSettingsContent = c.Binary(),
                        ChartSettingsContent = c.Binary(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Bank",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 16),
                        Name = c.String(nullable: false, maxLength: 64),
                        Address = c.String(maxLength: 128),
                        ContactName = c.String(maxLength: 128),
                        ContactDetails = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DashboardDatas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Content = c.String(maxLength: 2147483647),
                        Title = c.String(maxLength: 2147483647),
                        SynchronizeTitle = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Subject = c.String(maxLength: 2147483647),
                        Description = c.String(maxLength: 2147483647),
                        StartOn = c.DateTime(),
                        EndOn = c.DateTime(),
                        AllDay = c.Boolean(nullable: false),
                        Location = c.String(maxLength: 2147483647),
                        Label = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        RecurrenceInfoXml = c.String(maxLength: 300),
                        ReminderInfoXml = c.String(maxLength: 200),
                        RemindInSeconds = c.Int(nullable: false),
                        AlarmTime = c.DateTime(),
                        IsPostponed = c.Boolean(nullable: false),
                        RecurrencePattern_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Events", t => t.RecurrencePattern_ID)
                .Index(t => t.RecurrencePattern_ID);
            
            CreateTable(
                "dbo.Resources",
                c => new
                    {
                        Key = c.Int(nullable: false, identity: true),
                        Caption = c.String(maxLength: 2147483647),
                        Color_Int = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Key);
            
            CreateTable(
                "dbo.FileDatas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Size = c.Int(nullable: false),
                        FileName = c.String(maxLength: 2147483647),
                        Content = c.Binary(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.HCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 2147483647),
                        Parent_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.HCategories", t => t.Parent_ID)
                .Index(t => t.Parent_ID);
            
            CreateTable(
                "dbo.KpiDefinitions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 2147483647),
                        Active = c.Boolean(nullable: false),
                        TargetObjectTypeFullName = c.String(maxLength: 2147483647),
                        Criteria = c.String(maxLength: 2147483647),
                        Expression = c.String(maxLength: 2147483647),
                        GreenZone = c.Double(nullable: false, storeType: "real"),
                        RedZone = c.Double(nullable: false, storeType: "real"),
                        Compare = c.Boolean(nullable: false),
                        RangeName = c.String(maxLength: 2147483647),
                        RangeToCompareName = c.String(maxLength: 2147483647),
                        MeasurementFrequency = c.Int(nullable: false),
                        MeasurementMode = c.Int(nullable: false),
                        Direction = c.Int(nullable: false),
                        ChangedOn = c.DateTime(nullable: false),
                        SuppressedSeries = c.String(maxLength: 2147483647),
                        EnableCustomizeRepresentation = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.KpiInstances",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ForceMeasurementDateTime = c.DateTime(),
                        Settings = c.String(maxLength: 2147483647),
                        KpiDefinition_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.KpiDefinitions", t => t.KpiDefinition_ID, cascadeDelete: true)
                .Index(t => t.KpiDefinition_ID);
            
            CreateTable(
                "dbo.KpiHistoryItems",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RangeStart = c.DateTime(nullable: false),
                        RangeEnd = c.DateTime(nullable: false),
                        Value = c.Double(nullable: false, storeType: "real"),
                        KpiInstance_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.KpiInstances", t => t.KpiInstance_ID, cascadeDelete: true)
                .Index(t => t.KpiInstance_ID);
            
            CreateTable(
                "dbo.KpiScorecards",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 2147483647),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LocationType = c.Int(nullable: false),
                        ParentId = c.Int(),
                        Name = c.String(nullable: false, maxLength: 128),
                        Address = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Location", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.ModelDifferenceAspects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 2147483647),
                        Xml = c.String(maxLength: 2147483647),
                        Owner_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ModelDifferences", t => t.Owner_ID)
                .Index(t => t.Owner_ID);
            
            CreateTable(
                "dbo.ModelDifferences",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 2147483647),
                        ContextId = c.String(maxLength: 2147483647),
                        Version = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ModuleInfoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 2147483647),
                        Version = c.String(maxLength: 2147483647),
                        AssemblyFileName = c.String(maxLength: 2147483647),
                        IsMain = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ReportDataV2",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DataTypeName = c.String(maxLength: 2147483647),
                        IsInplaceReport = c.Boolean(nullable: false),
                        PredefinedReportTypeName = c.String(maxLength: 2147483647),
                        Content = c.Binary(),
                        DisplayName = c.String(maxLength: 2147483647),
                        ParametersObjectTypeName = c.String(maxLength: 2147483647),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PermissionPolicyRoleBases",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 2147483647),
                        IsAdministrative = c.Boolean(nullable: false),
                        CanEditModel = c.Boolean(nullable: false),
                        PermissionPolicy = c.Int(nullable: false),
                        IsAllowPermissionPriority = c.Boolean(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PermissionPolicyNavigationPermissionObjects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ItemPath = c.String(maxLength: 2147483647),
                        TargetTypeFullName = c.String(maxLength: 2147483647),
                        NavigateState = c.Int(),
                        Role_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PermissionPolicyRoleBases", t => t.Role_ID)
                .Index(t => t.Role_ID);
            
            CreateTable(
                "dbo.PermissionPolicyTypePermissionObjects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TargetTypeFullName = c.String(maxLength: 2147483647),
                        ReadState = c.Int(),
                        WriteState = c.Int(),
                        CreateState = c.Int(),
                        DeleteState = c.Int(),
                        NavigateState = c.Int(),
                        Role_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PermissionPolicyRoleBases", t => t.Role_ID)
                .Index(t => t.Role_ID);
            
            CreateTable(
                "dbo.PermissionPolicyMemberPermissionsObjects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Members = c.String(maxLength: 2147483647),
                        Criteria = c.String(maxLength: 2147483647),
                        ReadState = c.Int(),
                        WriteState = c.Int(),
                        TypePermissionObject_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PermissionPolicyTypePermissionObjects", t => t.TypePermissionObject_ID)
                .Index(t => t.TypePermissionObject_ID);
            
            CreateTable(
                "dbo.PermissionPolicyObjectPermissionsObjects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Criteria = c.String(maxLength: 2147483647),
                        ReadState = c.Int(),
                        WriteState = c.Int(),
                        DeleteState = c.Int(),
                        NavigateState = c.Int(),
                        TypePermissionObject_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PermissionPolicyTypePermissionObjects", t => t.TypePermissionObject_ID)
                .Index(t => t.TypePermissionObject_ID);
            
            CreateTable(
                "dbo.PermissionPolicyUsers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 2147483647),
                        IsActive = c.Boolean(nullable: false),
                        ChangePasswordOnFirstLogon = c.Boolean(nullable: false),
                        StoredPassword = c.String(maxLength: 2147483647),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ResourceEvents",
                c => new
                    {
                        Resource_Key = c.Int(nullable: false),
                        Event_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Resource_Key, t.Event_ID })
                .ForeignKey("dbo.Resources", t => t.Resource_Key, cascadeDelete: true)
                .ForeignKey("dbo.Events", t => t.Event_ID, cascadeDelete: true)
                .Index(t => t.Resource_Key)
                .Index(t => t.Event_ID);
            
            CreateTable(
                "dbo.KpiInstanceKpiScorecards",
                c => new
                    {
                        KpiInstance_ID = c.Int(nullable: false),
                        KpiScorecard_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.KpiInstance_ID, t.KpiScorecard_ID })
                .ForeignKey("dbo.KpiInstances", t => t.KpiInstance_ID, cascadeDelete: true)
                .ForeignKey("dbo.KpiScorecards", t => t.KpiScorecard_ID, cascadeDelete: true)
                .Index(t => t.KpiInstance_ID)
                .Index(t => t.KpiScorecard_ID);
            
            CreateTable(
                "dbo.PermissionPolicyUserPermissionPolicyRoles",
                c => new
                    {
                        PermissionPolicyUser_ID = c.Int(nullable: false),
                        PermissionPolicyRole_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PermissionPolicyUser_ID, t.PermissionPolicyRole_ID })
                .ForeignKey("dbo.PermissionPolicyUsers", t => t.PermissionPolicyUser_ID, cascadeDelete: true)
                .ForeignKey("dbo.PermissionPolicyRoleBases", t => t.PermissionPolicyRole_ID, cascadeDelete: true)
                .Index(t => t.PermissionPolicyUser_ID)
                .Index(t => t.PermissionPolicyRole_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PermissionPolicyUserPermissionPolicyRoles", "PermissionPolicyRole_ID", "dbo.PermissionPolicyRoleBases");
            DropForeignKey("dbo.PermissionPolicyUserPermissionPolicyRoles", "PermissionPolicyUser_ID", "dbo.PermissionPolicyUsers");
            DropForeignKey("dbo.PermissionPolicyTypePermissionObjects", "Role_ID", "dbo.PermissionPolicyRoleBases");
            DropForeignKey("dbo.PermissionPolicyObjectPermissionsObjects", "TypePermissionObject_ID", "dbo.PermissionPolicyTypePermissionObjects");
            DropForeignKey("dbo.PermissionPolicyMemberPermissionsObjects", "TypePermissionObject_ID", "dbo.PermissionPolicyTypePermissionObjects");
            DropForeignKey("dbo.PermissionPolicyNavigationPermissionObjects", "Role_ID", "dbo.PermissionPolicyRoleBases");
            DropForeignKey("dbo.ModelDifferenceAspects", "Owner_ID", "dbo.ModelDifferences");
            DropForeignKey("dbo.Location", "ParentId", "dbo.Location");
            DropForeignKey("dbo.KpiInstances", "KpiDefinition_ID", "dbo.KpiDefinitions");
            DropForeignKey("dbo.KpiInstanceKpiScorecards", "KpiScorecard_ID", "dbo.KpiScorecards");
            DropForeignKey("dbo.KpiInstanceKpiScorecards", "KpiInstance_ID", "dbo.KpiInstances");
            DropForeignKey("dbo.KpiHistoryItems", "KpiInstance_ID", "dbo.KpiInstances");
            DropForeignKey("dbo.HCategories", "Parent_ID", "dbo.HCategories");
            DropForeignKey("dbo.ResourceEvents", "Event_ID", "dbo.Events");
            DropForeignKey("dbo.ResourceEvents", "Resource_Key", "dbo.Resources");
            DropForeignKey("dbo.Events", "RecurrencePattern_ID", "dbo.Events");
            DropIndex("dbo.PermissionPolicyUserPermissionPolicyRoles", new[] { "PermissionPolicyRole_ID" });
            DropIndex("dbo.PermissionPolicyUserPermissionPolicyRoles", new[] { "PermissionPolicyUser_ID" });
            DropIndex("dbo.KpiInstanceKpiScorecards", new[] { "KpiScorecard_ID" });
            DropIndex("dbo.KpiInstanceKpiScorecards", new[] { "KpiInstance_ID" });
            DropIndex("dbo.ResourceEvents", new[] { "Event_ID" });
            DropIndex("dbo.ResourceEvents", new[] { "Resource_Key" });
            DropIndex("dbo.PermissionPolicyObjectPermissionsObjects", new[] { "TypePermissionObject_ID" });
            DropIndex("dbo.PermissionPolicyMemberPermissionsObjects", new[] { "TypePermissionObject_ID" });
            DropIndex("dbo.PermissionPolicyTypePermissionObjects", new[] { "Role_ID" });
            DropIndex("dbo.PermissionPolicyNavigationPermissionObjects", new[] { "Role_ID" });
            DropIndex("dbo.ModelDifferenceAspects", new[] { "Owner_ID" });
            DropIndex("dbo.Location", new[] { "ParentId" });
            DropIndex("dbo.KpiHistoryItems", new[] { "KpiInstance_ID" });
            DropIndex("dbo.KpiInstances", new[] { "KpiDefinition_ID" });
            DropIndex("dbo.HCategories", new[] { "Parent_ID" });
            DropIndex("dbo.Events", new[] { "RecurrencePattern_ID" });
            DropTable("dbo.PermissionPolicyUserPermissionPolicyRoles");
            DropTable("dbo.KpiInstanceKpiScorecards");
            DropTable("dbo.ResourceEvents");
            DropTable("dbo.PermissionPolicyUsers");
            DropTable("dbo.PermissionPolicyObjectPermissionsObjects");
            DropTable("dbo.PermissionPolicyMemberPermissionsObjects");
            DropTable("dbo.PermissionPolicyTypePermissionObjects");
            DropTable("dbo.PermissionPolicyNavigationPermissionObjects");
            DropTable("dbo.PermissionPolicyRoleBases");
            DropTable("dbo.ReportDataV2");
            DropTable("dbo.ModuleInfoes");
            DropTable("dbo.ModelDifferences");
            DropTable("dbo.ModelDifferenceAspects");
            DropTable("dbo.Location");
            DropTable("dbo.KpiScorecards");
            DropTable("dbo.KpiHistoryItems");
            DropTable("dbo.KpiInstances");
            DropTable("dbo.KpiDefinitions");
            DropTable("dbo.HCategories");
            DropTable("dbo.FileDatas");
            DropTable("dbo.Resources");
            DropTable("dbo.Events");
            DropTable("dbo.DashboardDatas");
            DropTable("dbo.Bank");
            DropTable("dbo.Analyses");
        }
    }
}
