using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSFMEdia.StatisProCardFactory.Business
{
    public class MarkupFactory
    {
        public static string BuildBootstrapAlertWarning(string alertText)
        {
            var stub = @"<div class=""alert alert-warning"" role=""alert"">{0}</div>";
            return string.Format(stub, alertText);
        }

        public static string BuildBootstrapAlertDanger(string alertText)
        {
            var stub = @"<div class=""alert alert-danger"" role=""alert"">{0}</div>";
            return string.Format(stub, alertText);
        }

        public static string BuildBootstrapAlertSuccess(string alertText)
        {
            var stub = @"<div class=""alert alert-success"" role=""alert"">{0}</div>";
            return string.Format(stub, alertText);
        }

        public static string BuildBootstrapAlertInfo(string alertText)
        {
            var stub = @"<div class=""alert alert-info"" role=""alert"">{0}</div>";
            return string.Format(stub, alertText);
        }

        public static string BuildBootstrapLabel(string text)
        {
            var stub = @"<span class=""label label-info"">{0}</span>";
            return string.Format(stub, text);
        }
    }
}