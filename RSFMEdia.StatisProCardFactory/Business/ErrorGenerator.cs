using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSFMEdia.StatisProCardFactory.Business
{
    public class ErrorGenerator
    {
        public static string BuildBootstrapAlertWarning(string alertText)
        {
            var stub = @"<div class=""alert alert-warning"" role=""alert"">{0}</div>";
            return string.Format(stub, alertText);
        }
    }
}