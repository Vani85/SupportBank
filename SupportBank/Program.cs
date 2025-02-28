using FileReader;
using Transaction;
using Account;
using Reports;
using NLog;
using Logging;

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

        private static void ProcessInputFiles(){
            string[] FileList = ReadFile.GetListOfAllFiles();
            Logger.Info("There are " +FileList.Count() + " files to be processed"); 
            for (int i = 0; i < FileList.Count(); i++){
                string FilePath = FileList[i];
                Console.WriteLine("Do you want to process "+ Path.GetFileName(FilePath) + "? Enter: Y / N ?");
                if(Console.ReadLine().ToUpper() == "Y"){
                    ProcessTransactionsForAFile(FilePath);
                }
            }

            Console.WriteLine("Processed all files in the folder.");

        } 

        private static void ProcessTransactionsForAFile(string filePath){
            List<TransactionDetails> transactions = null;
            if(Path.GetExtension(filePath).Contains("csv")) {
                transactions = ReadFile.ReadTransactionDetailsFromCsvFile(filePath);
            } else if(Path.GetExtension(filePath).Contains("json")) {
                transactions = ReadFile.ReadTransactionDetailsFromJsonFile(filePath);
            }
            AccountHelper accountHelper = new AccountHelper();
            accountHelper.UpdateAccounts(transactions);
            ReportGenerator reports = new ReportGenerator();
            reports.GenerateReport(accountHelper);
        }
          
    }
}
