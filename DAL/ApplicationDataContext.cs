using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DTO;


namespace DAL
{
    class ApplicationDataContext : DbContext
    {
        public DbSet<machine_monitoring_poortenDTO> machine_monitoring_poorten{ get; set; }
        public DbSet<monitoring_dataDTO> monitoring_data_202009 { get; set; }
        public DbSet<production_dataDTO> production_data { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            string server = "Server=127.18.0.2;Port=54049;Uid=root;Database=q3_mms_db;Pwd=dreamingsql;Convert Zero Datetime=True";
            //string server = "Server=studmysql01.fhict.local;Uid=dbi340421;Database=dbi340421;Pwd=Dreaming;Convert Zero Datetime=True";
            optionsBuilder.UseMySql(server, ServerVersion.AutoDetect(server), options => options.EnableRetryOnFailure());
        }

    }
}
