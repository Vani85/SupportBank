using Utils;

namespace Transaction {
    public class TransactionDetails {
         public DateTime Date {get;}
         public string FromAccount {get;}
         public string ToAccount {get;}
         public string Narrative {get;}
         public float Amount {get;}

        public TransactionDetails(DateTime date, string fromAccount, string toAccount,
        string narrative, float amount)
        {
            Date = date;
            FromAccount = fromAccount;
            ToAccount = toAccount;
            Narrative = narrative;
            Amount = amount;            
        }   

    }
}