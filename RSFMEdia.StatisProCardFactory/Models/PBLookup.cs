using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RSFMEdia.StatisProCardFactory.Models
{
    [Table("SPCF_PBLookup")]
    public class PBLookup
    {
        [Key]
        public int Id { get; set; }
        public int Year { get; set; }
        public string League { get; set; }
        public string PB { get; set; }
        public decimal HighestERA { get; set; }
    }
}