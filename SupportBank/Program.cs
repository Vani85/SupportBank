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
        public static List<TransactionDetails>? transactions = null;
        public static void Main() {
            LogConfig.ConfigureLog();
            Logger.Info("Start of the Support Bank Program");
            string[] FileList = ReadFile.GetListOfAllFiles();
            for (int i = 0; i < FileList.Count(); i++){
                string FileName = FileList[i];
                transactions = ReadFile.ReadTransactionDetailsFromCsvFile(FileName);           
           
                foreach (var transaction in transactions){
                    string from = transaction.TransactionFromPerson;
                    string to = transaction.TransactionToPerson;
                    DateTime date = transaction.TransactionDate;
                    string activity = transaction.ActivityName;
                    int amount = transaction.TransactionAmount;

                    if(!AccountHelper.IsAccountAvailableForUser(from)){
                        AccountHelper.CreateNewAccount(from);
                    }

                    if(!AccountHelper.IsAccountAvailableForUser(to)){
                        AccountHelper.CreateNewAccount(to);
                    }

                    AccountHelper.UpdateTransactionDetailsInAccount(from,new TransactionDetails(date,from,to,activity,amount),0,amount);           
                    AccountHelper.UpdateTransactionDetailsInAccount(to,new TransactionDetails(date,from,to,activity,amount),amount,0);
                    
                }
                ReportGenerator.GenerateReport();
            }    
        }
    }
}