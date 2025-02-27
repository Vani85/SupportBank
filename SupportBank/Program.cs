using FileReader;
using Transaction;
using Account;
using Reports;
using NLog;
using Logging;
//using NLog.Targets;
//using NLog.Config;
//using NLog.LayoutRenderers;


namespace SupportBank {
    class SupportBank {
        private static readonly ILogger Logger = LogManager.GetLogger("File Logger");
        public static void Main() {
            LogConfig.ConfigureLog();
            Logger.Info("*********************************************************"); 
            Logger.Info("Start of the Support Bank Program");
            ProcessInputFiles();
            Logger.Info("End of the Support Bank Program");
            Logger.Info("*********************************************************"); 
        } 

        public static void ProcessInputFiles(){
            string[] FileList = ReadFile.GetListOfAllFiles();
            Logger.Info("There are " +FileList.Count() + " files to be processed"); 
            for (int i = 0; i < FileList.Count(); i++){
                string FilePath = FileList[i];
                Console.WriteLine("Do you want to process "+ Path.GetFileName(FilePath) + "? Enter: Y / N ?");
                if(Console.ReadLine().ToUpper() == "Y"){
                    ProcessTransactionsForAFile(FilePath);
                  
                }
            }

        } 

        public static void ProcessTransactionsForAFile(string filePath){
            List<TransactionDetails> transactions = ReadFile.ReadTransactionDetailsFromCsvFile(filePath);
                    
            AccountHelper accountHelper = new AccountHelper();
            accountHelper.UpdateAccounts(transactions);
            ReportGenerator reports = new ReportGenerator();
            reports.GenerateReport(accountHelper);
        }
          
    }
}
