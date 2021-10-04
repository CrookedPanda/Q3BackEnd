using DTO;
using System;
using System.Collections.Generic;

namespace DAL
{
    public class ComponentDAL
    {
        public static void Main() {
        
            using (var db = new ApplicationDataContext()){
                
                // Create
                db.Add(new ComponentDTO {});
                db.SaveChanges();

                // Read
                var component = db.DATABASENAAM
                    .OrderBy(b => b.BlogId)
                    .First();

                // Update
                component.Url = "https://devblogs.microsoft.com/dotnet";
                component.ActionCount.Add(34873);
                db.SaveChanges();

                // Delete
                db.Remove(component);
                db.SaveChanges();
            }
        }
    }
}

