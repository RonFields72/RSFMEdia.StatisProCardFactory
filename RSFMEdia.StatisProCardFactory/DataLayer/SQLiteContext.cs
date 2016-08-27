using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using RSFMEdia.StatisProCardFactory.Models;

namespace RSFMEdia.StatisProCardFactory.DataLayer
{
    public class SQLiteContext : DbContext
    {
        public DbSet<PBLookup> PBLookups { get; set; }
        public DbSet<OBRLookup> OBRLookups { get; set; }
        public DbSet<SACLookup> SACLookups { get; set; }
        public DbSet<SPLookup> SPLookups { get; set; } 
    }
}