using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using RSFMEdia.StatisProCardFactory.Models;

namespace RSFMEdia.StatisProCardFactory.DataLayer
{
    public class SQLiteContext : DbContext
    {
        public SQLiteContext(string connectionString) : base(connectionString) { }
        public DbSet<PitcherControlFactor> PitcherControlFactor { get; set; }
        
    }
}