using Utils;

namespace Transaction {
    public class TransactionDetailsMapper {
         public string Date {get;}
         public string FromAccount {get;}
         public string ToAccount {get;}
         public string Narrative {get;}
         public float Amount {get;}

        public TransactionDetailsMapper(string date, string fromAccount, string toAccount,
        string narrative, float amount)
        {
            Date = date;
            FromAccount = fromAccount;
            ToAccount = toAccount;
            Narrative = narrative;
            Amount = amount;          
        }   
    }

     public class TransactionDetailsMapperToTransactionDetails
    {
        public List<TransactionDetails> ConvertToTransactionDetails(List<TransactionDetailsMapper> mapper)
        {          
            List<TransactionDetails> transactions = new List<TransactionDetails>();
            foreach(TransactionDetailsMapper transactionMapper in mapper) {
                transactions.Add(new TransactionDetails(
                    Utility.DateConverterStringToDate(transactionMapper.Date),                 
                    transactionMapper.FromAccount,          
                    transactionMapper.ToAccount,            
                    transactionMapper.Narrative,           
                    transactionMapper.Amount                
                ));
            }
            return transactions;
        }
    }
}