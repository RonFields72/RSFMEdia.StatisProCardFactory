using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RSFMEdia.StatisProCardFactory.Models
{
    [Table("SPCF_SACLookup")]
    public class SACLookup
    {
            [Key]
            public int Id { get; set; }
            public int SacrificeHits { get; set; }
            public string SAC { get; set; }
    }
}