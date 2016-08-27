using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RSFMEdia.StatisProCardFactory.Models
{
    public class OBRLookup
    {
        [Key]
        public int Id { get; set; }
        public int RunsPlusStolenBases { get; set; }
        public string OBR { get; set; }
    }
}