using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DTO;


namespace DAL
{
    class ApplicationDataContext : DbContext
    {
        public DbSet<machine_monitoring_poortenDTO> machine_Monitoring_Poorten{ get; set; }
        public DbSet<monitoring_dataDTO> monitoring_Data_202009 { get; set; }
        public DbSet<production_dataDTO> production_data { get; set; }
        public DbSet<treeviewDTO> treeview { get; set; }
        public DbSet<component_maintenanceDTO> component_maintenance { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            string server = "Server=studmysql01.fhict.local;Uid=dbi340421;Database=dbi340421;Pwd=Dreaming;Convert Zero Datetime=True";
            optionsBuilder.UseMySql(server, ServerVersion.AutoDetect(server), options => options.EnableRetryOnFailure());
        }

    }
}
