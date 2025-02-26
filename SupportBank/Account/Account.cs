using Transaction;

namespace Account{
     class AccountDetails {
        public string PersonName {get;}
        List<TransactionDetails> TransactionList = new List <TransactionDetails>();
        public int AmountBorrowed {get;set;}
        public int AmountLent {get;set;}

        public AccountDetails (string personName,List<TransactionDetails> transactionList, int amountBorrowed, int amountLent){
            PersonName = personName;
            TransactionList = transactionList;
            AmountBorrowed += amountBorrowed;
            AmountLent += amountLent;
        }
        public AccountDetails (string personName){
            PersonName = personName;
        }
        public List<TransactionDetails> GetTransactionDetails() {
            return this.TransactionList;
        }

        public void updateAmount(int borrowedAmount, int lentAmount) {
            this.AmountBorrowed += borrowedAmount;
            this.AmountLent += lentAmount;         
        }
    }
}