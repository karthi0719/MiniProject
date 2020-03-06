namespace MiniProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KARTHIKA : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.logindatas",
                c => new
                    {
                        uid = c.Int(nullable: false, identity: true),
                        uname = c.String(),
                        password = c.String(),
                        roleid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.uid);
            
            CreateTable(
                "dbo.requests",
                c => new
                    {
                        reqid = c.Int(nullable: false, identity: true),
                        skillname = c.String(),
                        sdate = c.DateTime(nullable: false),
                        edate = c.DateTime(nullable: false),
                        status = c.String(),
                        trainerid = c.Int(nullable: false),
                        execid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.reqid);
            
            CreateTable(
                "dbo.roles",
                c => new
                    {
                        rid = c.Int(nullable: false, identity: true),
                        rname = c.String(),
                    })
                .PrimaryKey(t => t.rid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.roles");
            DropTable("dbo.requests");
            DropTable("dbo.logindatas");
        }
    }
}
