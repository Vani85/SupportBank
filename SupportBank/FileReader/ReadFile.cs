using System.Data;
using Transaction;
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
                        TransactionDetails transaction = new TransactionDetails(
                            Utility.DateConverterStringToDate(values[0].Trim()), 
                            values[1].Trim(),
                            values[2].Trim(),
                            values[3].Trim(), 
                            Utility.MoneyConverterStringToInt(values[4].Trim()));
                        transactions.Add(transaction);
                    }
                    index++;   
                }
            }      
            return transactions;      
        }
    }        
}
