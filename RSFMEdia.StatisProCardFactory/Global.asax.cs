using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using RSFMEdia.StatisProCardFactory.Business;
using RSFMEdia.StatisProCardFactory.DataLayer;

namespace RSFMEdia.StatisProCardFactory
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Fires when the application is started
            // the license key for Aspose.Words for .NET can be handled in multiple ways:
            // 1) the license key (.lic file) can be placed into the bin folder with the Aspose.Words.dll file 
            // 2) the license key (.lic file) can be placed on a file share and given a complete path in the SetLicense method
            // 3) the license key (.lic file) can be added to the project and be set as an embedded resource in its properties window
            Aspose.Words.License wordsLicense = new Aspose.Words.License();
            wordsLicense.SetLicense("Aspose.Total.lic");
            Aspose.Pdf.License pdfLicense = new Aspose.Pdf.License();
            pdfLicense.SetLicense("Aspose.Total.lic");

            // create application directories
            var fileHelper = new FileHelper();
            fileHelper.CreateDirectory(SPCFConstants.SPCF_MASTER_DIRECTORY);
            fileHelper.CreateDirectory(SPCFConstants.SPCF_OUTPUT_DIRECTORY);
            fileHelper.CreateDirectory(SPCFConstants.SPCF_CSV_DIRECTORY);
            fileHelper.CreateDirectory(SPCFConstants.SPCF_DB_DIRECTORY);

            // create data dependencies (if necessary)
            var spcfData = new SPCFDataEngine();
            spcfData.CreateDB();
        }
    }
}