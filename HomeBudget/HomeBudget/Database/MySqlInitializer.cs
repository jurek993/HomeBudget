﻿using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace HomeBudget.Database
{
    public class MySqlInitializer : IDatabaseInitializer<AppDbContext>
    {
        public void InitializeDatabase(AppDbContext context)
        {
            if (!context.Database.Exists())
            {
                // if database did not exist before - create it
                context.Database.Create();
                context.Database.ExecuteSqlCommand("ALTER TABLE listofhoping");
            }
            else
            {
                // query to check if MigrationHistory table is present in the database
                var migrationHistoryTableExists = ((IObjectContextAdapter)context).ObjectContext.ExecuteStoreQuery<int>(
                string.Format(
                  "SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = '{0}' AND table_name = '__MigrationHistory'",
                  "homebudgetdb"));

                // if MigrationHistory table is not there (which is the case first time we run) - create it
                if (migrationHistoryTableExists.FirstOrDefault() == 0)
                {
                    context.Database.Delete();
                    context.Database.Create();
                }
            }
        }
    }
}