using SupportBank.Transaction;

namespace SupportBank.Account{
     class AccountDetails {
        public string PersonName {get;}
        List<TransactionDetails> TransactionList = new List <TransactionDetails>();
        public int AmountBorrowed {get;set;}
        public int AmountLent {get;set;}

        public AccountDetails (string personName,List<TransactionDetails> transactionList){
            PersonName = personName;
            TransactionList = transactionList;
        }
        public List<TransactionDetails> GetTransactionDetails() {
            return this.TransactionList;
        }

        public void updateAmountLent(int lentAmount) {
            this.AmountLent += lentAmount;
        }

        public void updateAmountBorrowed(int borrowedAmount) {
            this.AmountBorrowed += borrowedAmount;
        }
    }
}