using FileReader;
using Transaction;
using Account;
using Reports;

namespace SupportBank {
    class SupportBank {        
        public static void Main() {
            List<TransactionDetails> transactions = ReadFile.ReadTransactionDetailsFromCsvFile();

            AccountHelper accountHelper = new AccountHelper();
            accountHelper.UpdateAccounts(transactions);
            
            ReportGenerator reports = new ReportGenerator();
            reports.GenerateReport(accountHelper);
        }
    }
}