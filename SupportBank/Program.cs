using FileReader;
using Transaction;
using Account;
using Reports;


namespace SupportBank {
    class SupportBank {
        
        public static List<TransactionDetails>? transactions = null;
        public static void Main() {
            transactions = ReadFile.ReadTransactionDetailsFromCsvFile();

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