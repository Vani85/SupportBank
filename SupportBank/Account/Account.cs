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

        private void updateAmount(int amount, Boolean isLender) {
            if(isLender){
                AmountLent += amount;
            }else{
                AmountBorrowed += amount;  
            }      
        }

        public void addTransaction(TransactionDetails transaction, Boolean isLender) {
            TransactionList.Add(transaction);
            updateAmount(transaction.TransactionAmount, isLender);
        }
    }
}