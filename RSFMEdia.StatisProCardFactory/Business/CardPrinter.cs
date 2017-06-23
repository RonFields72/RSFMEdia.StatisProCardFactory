using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Aspose.Words;
using Aspose.Words.Fields;
using RSFMEdia.StatisProCardFactory.Models;

namespace RSFMEdia.StatisProCardFactory.Business
{
    public class CardPrinter
    {
        #region Properties
        private string _documentName;
        private string _templateDocumentName;
        private string documentNamePrefix;
        public List<string> _outputType;
        private string _documentPath;
        private string _templatePath;
        public List<string> _createdDocumentName;
        private bool _containsErrors;
        public List<string> _errors;

        public string TemplatePath
        {
            get { return _templatePath; }
            set { _templatePath = value; }
        }
        public string TemplateDocumentName
        {
            get { return _templateDocumentName; }
            set { _templateDocumentName = value; }
        }
        public string DocumentName
        {
            get { return _documentName; }
            set { _documentName = value; }
        }
        public string DocumentNamePrefix
        {
            get { return documentNamePrefix; }
            set { documentNamePrefix = value; }
        }
        public List<string> OutputType
        {
            get { return _outputType; }
        }
        public string DocumentPath
        {
            get { return _documentPath; }
            set { _documentPath = value; }
        }
        public List<string> CreatedDocumentName
        {
            get { return _createdDocumentName; }
        }
        public bool ContainsErrors
        {
            get { return _containsErrors; }
            set { _containsErrors = value; }
        }
        public List<string> Errors
        {
            get { return _errors; }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Writes the file out to the file system
        /// </summary>
        /// <param name="existingDoc">The word document</param>
        /// <param name="documentName">document name</param>
        /// <param name="documentPath">path to where the document should be written</param>
        public void WriteFile(Document existingDoc, string documentName, string documentPath)
        {
            existingDoc.Save(string.Format("{0}{1}", documentPath, documentName));
        }

        /// <summary>
        /// /// Writes the file out to the file system
        /// </summary>
        /// <param name="existingDoc">The document</param>
        /// <param name="outputTypes">The output types.</param>
        /// <param name="documentNamePrefix">The document name prefix.</param>
        /// <param name="additionalFileIdentifier">The additional file identifier(used to differentiate mulitlpe instances of the same document).</param>
        /// <param name="documentPath">The document path.</param>
        public void WriteFile(Document existingDoc, List<string> outputTypes, string documentNamePrefix, string accountNumber, string additionalFileIdentifier, string documentPath)
        {
            string completeFileName;

            foreach (string fileExt in outputTypes)
            {
                // construct complete file name
                completeFileName = string.Format("{0}{1}_{2}{3}", documentNamePrefix, accountNumber, additionalFileIdentifier, fileExt);

                existingDoc.Save(string.Format("{0}{1}", documentPath, completeFileName));

                if (fileExt.ToUpper() == ".PDF")
                {
                    this.CreatedDocumentName.Add(completeFileName);
                }
            }
        }

        public void PrintBatterCards(List<BatterCard> batterCards, CardProcessingConfiguration configSettings)
        {
            // define form field objects
            FormField ffTeam = null;
            FormField ffLeague = null;
            FormField ffYear = null;
            FormField ffName = null;
            FormField ffAge = null;
            FormField ffArm = null;
            FormField ffFielding = null;
            FormField ffSpecialRemarks = null;
            FormField ffOBR = null;
            FormField ffSP = null;
            FormField ffHAndR = null;
            FormField ffCD = null;
            FormField ffSAC = null;
            FormField ffInj = null;
            FormField ff1BF = null;
            FormField ff1B7 = null;
            FormField ff1B8 = null;
            FormField ff1B9 = null;
            FormField ff2B7 = null;
            FormField ff2B8 = null;
            FormField ff2B9 = null;
            FormField ff3B8 = null;
            FormField ffHR = null;
            FormField ffK = null;
            FormField ffBB = null;
            FormField ffHBP = null;
            FormField ffOut = null;
            FormField ffCht = null;
            FormField ffBDRating = null;
            FormField ffBD2B = null;
            FormField ffBD3B = null;
            FormField ffBDHR = null;
            FormField ffInfoG = null;
            FormField ffInfoAB = null;
            FormField ffInfoH = null;
            FormField ffInfoHR = null;
            FormField ffInfoRBI = null;
            FormField ffInfoAVG = null;
            FormField ffInfoSB = null;

            // create new documents from  the template - additional documents will be used as neeeded based on the number of batter cards
            bool usesSecondSheet = false;
            bool usesThirdSheet = false;
            bool usesFourthSheet = false;
            Document batterCardSheet = new Aspose.Words.Document("C:/temp/StatisProPlayerSheetTemplate_15.docx");
            Document batterCardSheet2 = new Aspose.Words.Document("C:/temp/StatisProPlayerSheetTemplate_15.docx");
            Document batterCardSheet3 = new Aspose.Words.Document("C:/temp/StatisProPlayerSheetTemplate_15.docx");
            Document batterCardSheet4 = new Aspose.Words.Document("C:/temp/StatisProPlayerSheetTemplate_15.docx");

            // init counters
            int cardCounter = 0;
            int sheetCounter1 = 0;
            int sheetCounter2 = 0;
            int sheetCounter3 = 0;
            int sheetCounter4 = 0;

            // loop through the batter cards and assign them to the appropriate document
            // each document template can print 15 batter cards 
            foreach (var batterCard in batterCards)
            {
                // increment the card counter
                cardCounter++;
                
                // sheet #1 (batter cards 1-15)
                if (cardCounter >= 1 && cardCounter <= 15)
                {
                    sheetCounter1++;
                    // create the form fields from the ones on the template
                    ffTeam = batterCardSheet.Range.FormFields["Team" + sheetCounter1.ToString()];
                    ffLeague = batterCardSheet.Range.FormFields["League" + sheetCounter1.ToString()];
                    ffYear = batterCardSheet.Range.FormFields["Year" + sheetCounter1.ToString()];
                    ffName = batterCardSheet.Range.FormFields["Name" + sheetCounter1.ToString()];
                    ffAge = batterCardSheet.Range.FormFields["Age" + sheetCounter1.ToString()];
                    ffArm = batterCardSheet.Range.FormFields["Arm" + sheetCounter1.ToString()];
                    ffFielding = batterCardSheet.Range.FormFields["Fielding" + sheetCounter1.ToString()];
                    ffSpecialRemarks = batterCardSheet.Range.FormFields["SpecialRemarks" + sheetCounter1.ToString()];
                    ffOBR = batterCardSheet.Range.FormFields["OBR" + sheetCounter1.ToString()];
                    ffSP = batterCardSheet.Range.FormFields["SP" + sheetCounter1.ToString()];
                    ffHAndR = batterCardSheet.Range.FormFields["HAndR" + sheetCounter1.ToString()];
                    ffCD = batterCardSheet.Range.FormFields["CD" + sheetCounter1.ToString()];
                    ffSAC = batterCardSheet.Range.FormFields["SAC" + sheetCounter1.ToString()];
                    ffInj = batterCardSheet.Range.FormFields["Inj" + sheetCounter1.ToString()];
                    ff1BF = batterCardSheet.Range.FormFields["Single1BF" + sheetCounter1.ToString()];
                    ff1B7 = batterCardSheet.Range.FormFields["Single1B7" + sheetCounter1.ToString()];
                    ff1B8 = batterCardSheet.Range.FormFields["Single1B8" + sheetCounter1.ToString()];
                    ff1B9 = batterCardSheet.Range.FormFields["Single1B9" + sheetCounter1.ToString()];
                    ff2B7 = batterCardSheet.Range.FormFields["Double2B7" + sheetCounter1.ToString()];
                    ff2B8 = batterCardSheet.Range.FormFields["Double2B8" + sheetCounter1.ToString()];
                    ff2B9 = batterCardSheet.Range.FormFields["Double2B9" + sheetCounter1.ToString()];
                    ff3B8 = batterCardSheet.Range.FormFields["Triple3B8" + sheetCounter1.ToString()];
                    ffHR = batterCardSheet.Range.FormFields["HR" + sheetCounter1.ToString()];
                    ffK = batterCardSheet.Range.FormFields["K" + sheetCounter1.ToString()];
                    ffBB = batterCardSheet.Range.FormFields["BB" + sheetCounter1.ToString()];
                    ffHBP = batterCardSheet.Range.FormFields["HBP" + sheetCounter1.ToString()];
                    ffOut = batterCardSheet.Range.FormFields["Out" + sheetCounter1.ToString()];
                    ffCht = batterCardSheet.Range.FormFields["Cht" + sheetCounter1.ToString()];
                    ffBDRating = batterCardSheet.Range.FormFields["BDRating" + sheetCounter1.ToString()];
                    ffBD2B = batterCardSheet.Range.FormFields["BD2B" + sheetCounter1.ToString()];
                    ffBD3B = batterCardSheet.Range.FormFields["BD3B" + sheetCounter1.ToString()];
                    ffBDHR = batterCardSheet.Range.FormFields["BDHR" + sheetCounter1.ToString()];
                    ffInfoG = batterCardSheet.Range.FormFields["InfoG" + sheetCounter1.ToString()];
                    ffInfoAB = batterCardSheet.Range.FormFields["InfoAB" + sheetCounter1.ToString()];
                    ffInfoH = batterCardSheet.Range.FormFields["InfoH" + sheetCounter1.ToString()];
                    ffInfoHR = batterCardSheet.Range.FormFields["InfoHR" + sheetCounter1.ToString()];
                    ffInfoRBI = batterCardSheet.Range.FormFields["InfoRBI" + sheetCounter1.ToString()];
                    ffInfoAVG = batterCardSheet.Range.FormFields["InfoAVG" + sheetCounter1.ToString()];
                    ffInfoSB = batterCardSheet.Range.FormFields["InfoSB" + sheetCounter1.ToString()];
                }

                // sheet #2 (batter cards 16-30)
                if (cardCounter >= 16 && cardCounter <= 30)
                {
                    usesSecondSheet = true;
                    sheetCounter2++;
                    // create the form fields from the ones on the template
                    ffTeam = batterCardSheet2.Range.FormFields["Team" + sheetCounter2.ToString()];
                    ffLeague = batterCardSheet2.Range.FormFields["League" + sheetCounter2.ToString()];
                    ffYear = batterCardSheet2.Range.FormFields["Year" + sheetCounter2.ToString()];
                    ffName = batterCardSheet2.Range.FormFields["Name" + sheetCounter2.ToString()];
                    ffAge = batterCardSheet2.Range.FormFields["Age" + sheetCounter2.ToString()];
                    ffArm = batterCardSheet2.Range.FormFields["Arm" + sheetCounter2.ToString()];
                    ffFielding = batterCardSheet2.Range.FormFields["Fielding" + sheetCounter2.ToString()];
                    ffSpecialRemarks = batterCardSheet2.Range.FormFields["SpecialRemarks" + sheetCounter2.ToString()];
                    ffOBR = batterCardSheet2.Range.FormFields["OBR" + sheetCounter2.ToString()];
                    ffSP = batterCardSheet2.Range.FormFields["SP" + sheetCounter2.ToString()];
                    ffHAndR = batterCardSheet2.Range.FormFields["HAndR" + sheetCounter2.ToString()];
                    ffCD = batterCardSheet2.Range.FormFields["CD" + sheetCounter2.ToString()];
                    ffSAC = batterCardSheet2.Range.FormFields["SAC" + sheetCounter2.ToString()];
                    ffInj = batterCardSheet2.Range.FormFields["Inj" + sheetCounter2.ToString()];
                    ff1BF = batterCardSheet2.Range.FormFields["Single1BF" + sheetCounter2.ToString()];
                    ff1B7 = batterCardSheet2.Range.FormFields["Single1B7" + sheetCounter2.ToString()];
                    ff1B8 = batterCardSheet2.Range.FormFields["Single1B8" + sheetCounter2.ToString()];
                    ff1B9 = batterCardSheet2.Range.FormFields["Single1B9" + sheetCounter2.ToString()];
                    ff2B7 = batterCardSheet2.Range.FormFields["Double2B7" + sheetCounter2.ToString()];
                    ff2B8 = batterCardSheet2.Range.FormFields["Double2B8" + sheetCounter2.ToString()];
                    ff2B9 = batterCardSheet2.Range.FormFields["Double2B9" + sheetCounter2.ToString()];
                    ff3B8 = batterCardSheet2.Range.FormFields["Triple3B8" + sheetCounter2.ToString()];
                    ffHR = batterCardSheet2.Range.FormFields["HR" + sheetCounter2.ToString()];
                    ffK = batterCardSheet2.Range.FormFields["K" + sheetCounter2.ToString()];
                    ffBB = batterCardSheet2.Range.FormFields["BB" + sheetCounter2.ToString()];
                    ffHBP = batterCardSheet2.Range.FormFields["HBP" + sheetCounter2.ToString()];
                    ffOut = batterCardSheet2.Range.FormFields["Out" + sheetCounter2.ToString()];
                    ffCht = batterCardSheet2.Range.FormFields["Cht" + sheetCounter2.ToString()];
                    ffBDRating = batterCardSheet2.Range.FormFields["BDRating" + sheetCounter2.ToString()];
                    ffBD2B = batterCardSheet2.Range.FormFields["BD2B" + sheetCounter2.ToString()];
                    ffBD3B = batterCardSheet2.Range.FormFields["BD3B" + sheetCounter2.ToString()];
                    ffBDHR = batterCardSheet2.Range.FormFields["BDHR" + sheetCounter2.ToString()];
                    ffInfoG = batterCardSheet2.Range.FormFields["InfoG" + sheetCounter2.ToString()];
                    ffInfoAB = batterCardSheet2.Range.FormFields["InfoAB" + sheetCounter2.ToString()];
                    ffInfoH = batterCardSheet2.Range.FormFields["InfoH" + sheetCounter2.ToString()];
                    ffInfoHR = batterCardSheet2.Range.FormFields["InfoHR" + sheetCounter2.ToString()];
                    ffInfoRBI = batterCardSheet2.Range.FormFields["InfoRBI" + sheetCounter2.ToString()];
                    ffInfoAVG = batterCardSheet2.Range.FormFields["InfoAVG" + sheetCounter2.ToString()];
                    ffInfoSB = batterCardSheet2.Range.FormFields["InfoSB" + sheetCounter2.ToString()];
                }

                // sheet #3 (batter cards 31-45)
                if (cardCounter >= 31 && cardCounter <= 45)
                {
                    usesThirdSheet = true;
                    sheetCounter3++;
                    // create the form fields from the ones on the template
                    ffTeam = batterCardSheet3.Range.FormFields["Team" + sheetCounter3.ToString()];
                    ffLeague = batterCardSheet3.Range.FormFields["League" + sheetCounter3.ToString()];
                    ffYear = batterCardSheet3.Range.FormFields["Year" + sheetCounter3.ToString()];
                    ffName = batterCardSheet3.Range.FormFields["Name" + sheetCounter3.ToString()];
                    ffAge = batterCardSheet3.Range.FormFields["Age" + sheetCounter3.ToString()];
                    ffArm = batterCardSheet3.Range.FormFields["Arm" + sheetCounter3.ToString()];
                    ffFielding = batterCardSheet3.Range.FormFields["Fielding" + sheetCounter3.ToString()];
                    ffSpecialRemarks = batterCardSheet3.Range.FormFields["SpecialRemarks" + sheetCounter3.ToString()];
                    ffOBR = batterCardSheet3.Range.FormFields["OBR" + sheetCounter3.ToString()];
                    ffSP = batterCardSheet3.Range.FormFields["SP" + sheetCounter3.ToString()];
                    ffHAndR = batterCardSheet3.Range.FormFields["HAndR" + sheetCounter3.ToString()];
                    ffCD = batterCardSheet3.Range.FormFields["CD" + sheetCounter3.ToString()];
                    ffSAC = batterCardSheet3.Range.FormFields["SAC" + sheetCounter3.ToString()];
                    ffInj = batterCardSheet3.Range.FormFields["Inj" + sheetCounter3.ToString()];
                    ff1BF = batterCardSheet3.Range.FormFields["Single1BF" + sheetCounter3.ToString()];
                    ff1B7 = batterCardSheet3.Range.FormFields["Single1B7" + sheetCounter3.ToString()];
                    ff1B8 = batterCardSheet3.Range.FormFields["Single1B8" + sheetCounter3.ToString()];
                    ff1B9 = batterCardSheet3.Range.FormFields["Single1B9" + sheetCounter3.ToString()];
                    ff2B7 = batterCardSheet3.Range.FormFields["Double2B7" + sheetCounter3.ToString()];
                    ff2B8 = batterCardSheet3.Range.FormFields["Double2B8" + sheetCounter3.ToString()];
                    ff2B9 = batterCardSheet3.Range.FormFields["Double2B9" + sheetCounter3.ToString()];
                    ff3B8 = batterCardSheet3.Range.FormFields["Triple3B8" + sheetCounter3.ToString()];
                    ffHR = batterCardSheet3.Range.FormFields["HR" + sheetCounter3.ToString()];
                    ffK = batterCardSheet3.Range.FormFields["K" + sheetCounter3.ToString()];
                    ffBB = batterCardSheet3.Range.FormFields["BB" + sheetCounter3.ToString()];
                    ffHBP = batterCardSheet3.Range.FormFields["HBP" + sheetCounter3.ToString()];
                    ffOut = batterCardSheet3.Range.FormFields["Out" + sheetCounter3.ToString()];
                    ffCht = batterCardSheet3.Range.FormFields["Cht" + sheetCounter3.ToString()];
                    ffBDRating = batterCardSheet3.Range.FormFields["BDRating" + sheetCounter3.ToString()];
                    ffBD2B = batterCardSheet3.Range.FormFields["BD2B" + sheetCounter3.ToString()];
                    ffBD3B = batterCardSheet3.Range.FormFields["BD3B" + sheetCounter3.ToString()];
                    ffBDHR = batterCardSheet3.Range.FormFields["BDHR" + sheetCounter3.ToString()];
                    ffInfoG = batterCardSheet3.Range.FormFields["InfoG" + sheetCounter3.ToString()];
                    ffInfoAB = batterCardSheet3.Range.FormFields["InfoAB" + sheetCounter3.ToString()];
                    ffInfoH = batterCardSheet3.Range.FormFields["InfoH" + sheetCounter3.ToString()];
                    ffInfoHR = batterCardSheet3.Range.FormFields["InfoHR" + sheetCounter3.ToString()];
                    ffInfoRBI = batterCardSheet3.Range.FormFields["InfoRBI" + sheetCounter3.ToString()];
                    ffInfoAVG = batterCardSheet3.Range.FormFields["InfoAVG" + sheetCounter3.ToString()];
                    ffInfoSB = batterCardSheet3.Range.FormFields["InfoSB" + sheetCounter3.ToString()];
                }

                // sheet #4 (batter cards 46-60)
                if (cardCounter >= 46 && cardCounter <= 60)
                {
                    usesFourthSheet = true;
                    sheetCounter4++;
                    // create the form fields from the ones on the template
                    ffTeam = batterCardSheet4.Range.FormFields["Team" + sheetCounter4.ToString()];
                    ffLeague = batterCardSheet4.Range.FormFields["League" + sheetCounter4.ToString()];
                    ffYear = batterCardSheet4.Range.FormFields["Year" + sheetCounter4.ToString()];
                    ffName = batterCardSheet4.Range.FormFields["Name" + sheetCounter4.ToString()];
                    ffAge = batterCardSheet4.Range.FormFields["Age" + sheetCounter4.ToString()];
                    ffArm = batterCardSheet4.Range.FormFields["Arm" + sheetCounter4.ToString()];
                    ffFielding = batterCardSheet4.Range.FormFields["Fielding" + sheetCounter4.ToString()];
                    ffSpecialRemarks = batterCardSheet4.Range.FormFields["SpecialRemarks" + sheetCounter4.ToString()];
                    ffOBR = batterCardSheet4.Range.FormFields["OBR" + sheetCounter4.ToString()];
                    ffSP = batterCardSheet4.Range.FormFields["SP" + sheetCounter4.ToString()];
                    ffHAndR = batterCardSheet4.Range.FormFields["HAndR" + sheetCounter4.ToString()];
                    ffCD = batterCardSheet4.Range.FormFields["CD" + sheetCounter4.ToString()];
                    ffSAC = batterCardSheet4.Range.FormFields["SAC" + sheetCounter4.ToString()];
                    ffInj = batterCardSheet4.Range.FormFields["Inj" + sheetCounter4.ToString()];
                    ff1BF = batterCardSheet4.Range.FormFields["Single1BF" + sheetCounter4.ToString()];
                    ff1B7 = batterCardSheet4.Range.FormFields["Single1B7" + sheetCounter4.ToString()];
                    ff1B8 = batterCardSheet4.Range.FormFields["Single1B8" + sheetCounter4.ToString()];
                    ff1B9 = batterCardSheet4.Range.FormFields["Single1B9" + sheetCounter4.ToString()];
                    ff2B7 = batterCardSheet4.Range.FormFields["Double2B7" + sheetCounter4.ToString()];
                    ff2B8 = batterCardSheet4.Range.FormFields["Double2B8" + sheetCounter4.ToString()];
                    ff2B9 = batterCardSheet4.Range.FormFields["Double2B9" + sheetCounter4.ToString()];
                    ff3B8 = batterCardSheet4.Range.FormFields["Triple3B8" + sheetCounter4.ToString()];
                    ffHR = batterCardSheet4.Range.FormFields["HR" + sheetCounter4.ToString()];
                    ffK = batterCardSheet4.Range.FormFields["K" + sheetCounter4.ToString()];
                    ffBB = batterCardSheet4.Range.FormFields["BB" + sheetCounter4.ToString()];
                    ffHBP = batterCardSheet4.Range.FormFields["HBP" + sheetCounter4.ToString()];
                    ffOut = batterCardSheet4.Range.FormFields["Out" + sheetCounter4.ToString()];
                    ffCht = batterCardSheet4.Range.FormFields["Cht" + sheetCounter4.ToString()];
                    ffBDRating = batterCardSheet4.Range.FormFields["BDRating" + sheetCounter4.ToString()];
                    ffBD2B = batterCardSheet4.Range.FormFields["BD2B" + sheetCounter4.ToString()];
                    ffBD3B = batterCardSheet4.Range.FormFields["BD3B" + sheetCounter4.ToString()];
                    ffBDHR = batterCardSheet4.Range.FormFields["BDHR" + sheetCounter4.ToString()];
                    ffInfoG = batterCardSheet4.Range.FormFields["InfoG" + sheetCounter4.ToString()];
                    ffInfoAB = batterCardSheet4.Range.FormFields["InfoAB" + sheetCounter4.ToString()];
                    ffInfoH = batterCardSheet4.Range.FormFields["InfoH" + sheetCounter4.ToString()];
                    ffInfoHR = batterCardSheet4.Range.FormFields["InfoHR" + sheetCounter4.ToString()];
                    ffInfoRBI = batterCardSheet4.Range.FormFields["InfoRBI" + sheetCounter4.ToString()];
                    ffInfoAVG = batterCardSheet4.Range.FormFields["InfoAVG" + sheetCounter4.ToString()];
                    ffInfoSB = batterCardSheet4.Range.FormFields["InfoSB" + sheetCounter4.ToString()];
                }

                // populate the form fields
                ffTeam.Result = batterCard.Team;
                ffLeague.Result = batterCard.League;
                ffYear.Result = batterCard.Year;
                ffName.Result = batterCard.Name;
                ffAge.Result = batterCard.Age;
                ffArm.Result = batterCard.Arm;
                ffFielding.Result = batterCard.Fielding;
                ffSpecialRemarks.Result = batterCard.Remarks;
                ffOBR.Result = batterCard.OBR;
                ffSP.Result = batterCard.SP;
                ffHAndR.Result = batterCard.HandR;
                ffCD.Result = batterCard.CD;
                ffSAC.Result = batterCard.SAC;
                ffInj.Result = batterCard.Inj;
                ff1BF.Result = batterCard.Single1BF;
                ff1B7.Result = batterCard.Single1B7;
                ff1B8.Result = batterCard.Single1B8;
                ff1B9.Result = batterCard.Single1B9;
                ff2B7.Result = batterCard.Double2B7;
                ff2B8.Result = batterCard.Double2B8;
                ff2B9.Result = batterCard.Double2B9;
                ff3B8.Result = batterCard.Triple3B8;
                ffHR.Result = batterCard.HR;
                ffK.Result = batterCard.K;
                ffBB.Result = batterCard.W;
                ffHBP.Result = batterCard.HBP;
                ffOut.Result = batterCard.Out;
                ffCht.Result = batterCard.Cht;
                ffBDRating.Result = batterCard.BDRating;
                ffBD2B.Result = batterCard.BDDouble;
                ffBD3B.Result = batterCard.BDTriple;
                ffBDHR.Result = batterCard.BDHomerun;
                ffInfoG.Result = batterCard.InfoGames;
                ffInfoAB.Result = batterCard.InfoAtBats;
                ffInfoH.Result = batterCard.InfoHits;
                ffInfoHR.Result = batterCard.InfoHomeruns;
                ffInfoRBI.Result = batterCard.InfoRBI;
                ffInfoAVG.Result = batterCard.InfoAVG;
                ffInfoSB.Result = batterCard.InfoStolenBases;
            }

            // create a name for the output file based on the settings entered
            var battingFilename = string.Format(SPCFConstants.SPCF_OUTPUT_NAMING_BATTER, configSettings.Year, configSettings.TeamAbbrev, configSettings.League);

            // concatenate the files (if necessary)
            if (usesSecondSheet)
            {
                batterCardSheet.AppendDocument(batterCardSheet2, ImportFormatMode.KeepSourceFormatting);
            }
            if (usesThirdSheet)
            {
                batterCardSheet.AppendDocument(batterCardSheet3, ImportFormatMode.KeepSourceFormatting);
            }
            if (usesFourthSheet)
            {
                batterCardSheet.AppendDocument(batterCardSheet4, ImportFormatMode.KeepSourceFormatting);
            }

            // create the batter cards file
            WriteFile(batterCardSheet, battingFilename, SPCFConstants.SPCF_OUTPUT_DIRECTORY);
        }

        public void PrintPitcherCards(List<PitcherCard> pitcherCards, CardProcessingConfiguration configSettings)
        {

        }
        #endregion
    }
}