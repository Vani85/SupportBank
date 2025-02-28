using Transaction;

namespace Account{
     class AccountDetails {
        public string PersonName {get;}
        public List<TransactionDetails> TransactionList {get;}
        public int AmountBorrowed {get;private set;}
        public int AmountLent {get;private set;}

        public AccountDetails (string personName,List<TransactionDetails> transactionList, int amountBorrowed, int amountLent){
            PersonName = personName;
            TransactionList = transactionList;
            AmountBorrowed = amountBorrowed;
            AmountLent = amountLent;
        }
        public AccountDetails (string personName){
            PersonName = personName;
            TransactionList = new List<TransactionDetails>();
        }

        private void updateAmount(float amount, Boolean isLender) {
            int AmountInPence = Convert.ToInt32(amount * 100);
            if(isLender){
                AmountLent += AmountInPence;
            }else{
                AmountBorrowed += AmountInPence;  
            }      
        }

        public void addTransaction(TransactionDetails transaction, Boolean isLender) {
            TransactionList.Add(transaction);
            updateAmount(transaction.Amount, isLender);
        }
    }
}