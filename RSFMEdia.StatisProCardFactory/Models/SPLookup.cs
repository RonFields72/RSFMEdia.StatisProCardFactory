using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RSFMEdia.StatisProCardFactory.Models
{
    [Table("SPCF_SPLookup")]
    public class SPLookup
    {
        [Key]
        public int Id { get; set; }
        public int StolenBases { get; set; }
        public string SP { get; set; }
    }
}