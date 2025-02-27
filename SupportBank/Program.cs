using FileReader;
using Transaction;
using Account;
using Reports;
using NLog;
using Logging;
using NLog.Targets;
using NLog.Config;
using NLog.LayoutRenderers;


namespace SupportBank {
    class SupportBank {
        private static readonly ILogger Logger = LogManager.GetLogger("File Logger");
        public static void Main() {
            LogConfig.ConfigureLog();
            Logger.Info("Start of the Support Bank Program");
            string[] FileList = ReadFile.GetListOfAllFiles();
            for (int i = 0; i < FileList.Count(); i++){
               string FileName = FileList[i];           
               List<TransactionDetails> transactions = ReadFile.ReadTransactionDetailsFromCsvFile(FileName);

               AccountHelper accountHelper = new AccountHelper();
               accountHelper.UpdateAccounts(transactions);
            
                ReportGenerator reports = new ReportGenerator();
                reports.GenerateReport(accountHelper);
            }
        }    
        }
    }
