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
            var firstCardSet = new List<BatterCard>();
            var secondCardSet = new List<BatterCard>();
            var thirdCardSet = new List<BatterCard>();
            var fourthCardSet = new List<BatterCard>();
            if (batterCards.Count <= 15)
            {
                firstCardSet = batterCards;
            }
            else
            {
                if (batterCards.Count > 30)
                {

                }
                else
                {
                    secondCardSet
                }
            }
            // determine how many sheets to print (15 cards fit on one sheet)
            int sheets = (int) Math.Ceiling((double) batterCards.Count / 15);
            if (sheets == 1)
            {

            }
            // create a new document from  the template
            bool usesSecondSheet = false;
            bool usesThirdSheet = false;
            bool usesFourthSheet = false;
            Document batterCardSheet = new Aspose.Words.Document("C:/temp/StatisProPlayerSheetTemplate_15.docx");
            Document batterCardSheet2 = new Aspose.Words.Document("C:/temp/StatisProPlayerSheetTemplate_15.docx");
            Document batterCardSheet3 = new Aspose.Words.Document("C:/temp/StatisProPlayerSheetTemplate_15.docx");
            Document batterCardSheet4 = new Aspose.Words.Document("C:/temp/StatisProPlayerSheetTemplate_15.docx");

            int cardCounter = 0;
            
            foreach (var batterCard in batterCards)
            {
                cardCounter++;
                Document newDoc = batterCardSheet;
                // sheet #1 (batter cards 1-15)
                // create the form fields from the ones on the template
                FormField ffTeam = batterCardSheet.Range.FormFields["Team" + cardCounter.ToString()];
                FormField ffLeague = batterCardSheet.Range.FormFields["League" + cardCounter.ToString()];
                FormField ffYear = batterCardSheet.Range.FormFields["Year" + cardCounter.ToString()];
                FormField ffName = batterCardSheet.Range.FormFields["Name" + cardCounter.ToString()];
                FormField ffAge = batterCardSheet.Range.FormFields["Age" + cardCounter.ToString()];
                FormField ffArm = batterCardSheet.Range.FormFields["Arm" + cardCounter.ToString()];
                FormField ffFielding = batterCardSheet.Range.FormFields["Fielding" + i.ToString()];
                FormField ffSpecialRemarks = batterCardSheet.Range.FormFields["SpecialRemarks" + i.ToString()];
                FormField ffOBR = batterCardSheet.Range.FormFields["OBR" + i.ToString()];
                FormField ffSP = batterCardSheet.Range.FormFields["SP" + i.ToString()];
                FormField ffHAndR = batterCardSheet.Range.FormFields["HAndR" + i.ToString()];
                FormField ffCD = batterCardSheet.Range.FormFields["CD" + i.ToString()];
                FormField ffSAC = batterCardSheet.Range.FormFields["SAC" + i.ToString()];
                FormField ffInj = batterCardSheet.Range.FormFields["Inj" + i.ToString()];
                FormField ff1BF = batterCardSheet.Range.FormFields["Single1BF" + i.ToString()];
                FormField ff1B7 = batterCardSheet.Range.FormFields["Single1B7" + i.ToString()];
                FormField ff1B8 = batterCardSheet.Range.FormFields["Single1B8" + i.ToString()];
                FormField ff1B9 = batterCardSheet.Range.FormFields["Single1B9" + i.ToString()];
                FormField ff2B7 = batterCardSheet.Range.FormFields["Double2B7" + i.ToString()];
                FormField ff2B8 = batterCardSheet.Range.FormFields["Double2B8" + i.ToString()];
                FormField ff2B9 = batterCardSheet.Range.FormFields["Double2B9" + i.ToString()];
                FormField ff3B8 = batterCardSheet.Range.FormFields["Triple3B8" + i.ToString()];
                FormField ffHR = batterCardSheet.Range.FormFields["HR" + i.ToString()];
                FormField ffK = batterCardSheet.Range.FormFields["K" + i.ToString()];
                FormField ffBB = batterCardSheet.Range.FormFields["BB" + i.ToString()];
                FormField ffHBP = batterCardSheet.Range.FormFields["HBP" + i.ToString()];
                FormField ffOut = batterCardSheet.Range.FormFields["Out" + i.ToString()];
                FormField ffCht = batterCardSheet.Range.FormFields["Cht" + i.ToString()];
                FormField ffBDRating = batterCardSheet.Range.FormFields["BDRating" + i.ToString()];
                FormField ffBD2B = batterCardSheet.Range.FormFields["BD2B" + i.ToString()];
                FormField ffBD3B = batterCardSheet.Range.FormFields["BD3B" + i.ToString()];
                FormField ffBDHR = batterCardSheet.Range.FormFields["BDHR" + i.ToString()];
                FormField ffInfoG = batterCardSheet.Range.FormFields["InfoG" + i.ToString()];
                FormField ffInfoAB = batterCardSheet.Range.FormFields["InfoAB" + i.ToString()];
                FormField ffInfoH = batterCardSheet.Range.FormFields["InfoH" + i.ToString()];
                FormField ffInfoHR = batterCardSheet.Range.FormFields["InfoHR" + i.ToString()];
                FormField ffInfoRBI = batterCardSheet.Range.FormFields["InfoRBI" + i.ToString()];
                FormField ffInfoAVG = batterCardSheet.Range.FormFields["InfoAVG" + i.ToString()];
                FormField ffInfoSB = batterCardSheet.Range.FormFields["InfoSB" + i.ToString()];

                // sheet #2 (batter cards 16-30)

                // sheet #3 (batter cards 31-45)

                // sheet #4 (batter cards 46-60)


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
                
            

            // create a second sheet of betters if required
            if (sheets >= 2)
            {

            }

            // create a third sheet of batters if required
            if (sheets >= 3)
            {

            }

            //FormField ffTeam = batterTemplate.Range.FormFields["Team1"];
            //FormField ffLeague = batterTemplate.Range.FormFields["League1"];
            //FormField ffYear = batterTemplate.Range.FormFields["Year1"];
            //FormField ffName = batterTemplate.Range.FormFields["Name1"];
            //FormField ffAge = batterTemplate.Range.FormFields["Age1"];
            //FormField ffArm = batterTemplate.Range.FormFields["Arm1"];
            //FormField ffFielding = batterTemplate.Range.FormFields["Fielding1"];
            //FormField ffSpecialRemarks = batterTemplate.Range.FormFields["SpecialRemarks1"];
            //FormField ffOBR = batterTemplate.Range.FormFields["OBR1"];
            //FormField ffSP = batterTemplate.Range.FormFields["SP1"];
            //FormField ffHAndR = batterTemplate.Range.FormFields["HAndR1"];
            //FormField ffCD = batterTemplate.Range.FormFields["CD1"];
            //FormField ffSAC = batterTemplate.Range.FormFields["SAC1"];
            //FormField ffInj = batterTemplate.Range.FormFields["Inj1"];
            //FormField ff1BF = batterTemplate.Range.FormFields["Single1BF1"];
            //FormField ff1B7 = batterTemplate.Range.FormFields["Single1B71"];
            //FormField ff1B8 = batterTemplate.Range.FormFields["Single1B81"];
            //FormField ff1B9 = batterTemplate.Range.FormFields["Single1B91"];
            //FormField ff2B7 = batterTemplate.Range.FormFields["Double2B71"];
            //FormField ff2B8 = batterTemplate.Range.FormFields["Double2B81"];
            //FormField ff2B9 = batterTemplate.Range.FormFields["Double2B91"];
            //FormField ff3B8 = batterTemplate.Range.FormFields["Triple3B81"];
            //FormField ffHR = batterTemplate.Range.FormFields["HR1"];
            //FormField ffK = batterTemplate.Range.FormFields["K1"];
            //FormField ffBB = batterTemplate.Range.FormFields["BB1"];
            //FormField ffHBP = batterTemplate.Range.FormFields["HBP1"];
            //FormField ffOut = batterTemplate.Range.FormFields["Out1"];
            //FormField ffCht = batterTemplate.Range.FormFields["Cht1"];
            //FormField ffBDRating = batterTemplate.Range.FormFields["BDRating1"];
            //FormField ffBD2B = batterTemplate.Range.FormFields["BD2B1"];
            //FormField ffBD3B = batterTemplate.Range.FormFields["BD3B1"];
            //FormField ffBDHR = batterTemplate.Range.FormFields["BDHR1"];
            //FormField ffInfoG = batterTemplate.Range.FormFields["InfoG1"];
            //FormField ffInfoAB = batterTemplate.Range.FormFields["InfoAB1"];
            //FormField ffInfoH = batterTemplate.Range.FormFields["InfoH1"];
            //FormField ffInfoHR = batterTemplate.Range.FormFields["InfoHR1"];
            //FormField ffInfoRBI = batterTemplate.Range.FormFields["InfoRBI1"];
            //FormField ffInfoAVG = batterTemplate.Range.FormFields["InfoAVG1"];
            //FormField ffInfoSB = batterTemplate.Range.FormFields["InfoSB1"];

            

            // create a name for the output file based on the settings entered
            var battingFilename = string.Format(SPCFConstants.SPCF_OUTPUT_NAMING_BATTER, configSettings.Year, configSettings.TeamAbbrev, configSettings.League);

            // concatenate the files
            if (usesSecondTemplate)
            {
                batterCardSheet.AppendDocument(batterCardsAdditional1, ImportFormatMode.KeepSourceFormatting);
            }
            if (usesThirdTemplate)
            {
                batterCardSheet.AppendDocument(batterCardsAdditional2, ImportFormatMode.KeepSourceFormatting);
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