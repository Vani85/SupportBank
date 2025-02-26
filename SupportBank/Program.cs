using FileReader;
using SupportBank.Transaction;

namespace SupportBank {
    class SupportBank {
        public static void Main() {
            List<TransactionDetails> transactions = ReadFile.ReadTransactionDetailsFromCsvFile();
        }
    }
}