using FileReader;
using Transaction;
using Account;
using Reports;

namespace SupportBank {
    class SupportBank {        
        public static void Main() {
            List<TransactionDetails> transactions = ReadFile.ReadTransactionDetailsFromCsvFile();

            AccountHelper accountHelper = new AccountHelper();
            foreach (var transaction in transactions){
                string from = transaction.TransactionFromPerson;
                string to = transaction.TransactionToPerson; 

                if(!accountHelper.IsAccountAvailableForUser(from)){
                    accountHelper.CreateNewAccount(from);
                }

                if(!accountHelper.IsAccountAvailableForUser(to)){
                    accountHelper.CreateNewAccount(to);
                }

                accountHelper.UpdateTransactionDetailsInAccount(from,transaction,true);           
                accountHelper.UpdateTransactionDetailsInAccount(to,transaction,false);
                
            }
            ReportGenerator reports = new ReportGenerator();
            reports.GenerateReport(accountHelper);
        }
    }
}