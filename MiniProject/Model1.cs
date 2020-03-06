


namespace MiniProject
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Data;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Mini : DbContext
    {
        // Your context has been configured to use a 'Model1' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'TrainingRequestCodeChal_21_2.Model1' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model1' 
        // connection string in the application configuration file.
        public Mini()
            : base("Model")
        {
            Database.SetInitializer<Mini>(new DropCreateDatabaseIfModelChanges<Mini>());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<logindata> logindatas { get; set; }
        public virtual DbSet<request> requests { get; set; }
        public virtual DbSet<role> roles { get; set; }
    }

    public class logindata
    {
        [Key]
        public int uid { get; set; }
        public string uname { get; set; }
        public string password { get; set; }
        public int roleid { get; set; }
    }
    public class request
    {
        [Key]
        public int reqid { get; set; }
        public string skillname { get; set; }
        public DateTime sdate { get; set; }
        public DateTime edate { get; set; }
        public string status { get; set; }
        public int trainerid { get; set; }
        public int execid { get; set; }
    }
    public class role
    {
        [Key]
        public int rid { get; set; }
        public string rname { get; set; }
    }
}





