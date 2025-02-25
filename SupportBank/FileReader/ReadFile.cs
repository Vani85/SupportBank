using System.Data;
using SupportBank.Transaction;
using Utils;
namespace FileReader {
    class ReadFile {
        public static string FileName = "Transactions2014.csv";
        public static List<TransactionDetails> ReadTransactionDetailsFromCsvFile() {
            List<TransactionDetails> transactions = new List<TransactionDetails>();
            using(var reader = new StreamReader(@"./FileReader/"+FileName))
            {
                int index = 0;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line?.Split(',');
                    if(index != 0) {
                        TransactionDetails transaction = new TransactionDetails(Utility.DateConverterStringToDate(values[0]), 
                                    values[1], values[2],values[3], Utility.MoneyConverterStringToInt(values[4]));
                        transactions.Add(transaction);
                    }
                    index++;   
                }
            }      
            return transactions;      
        }
    }        
}
