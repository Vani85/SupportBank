using SupportBank.Transaction;

namespace Account{
     class Account{
        string PersonName;
        List<TransactionDetails> TransactionList = new List <TransactionDetails>();
        int AmountBorrowed;
        int AmountLent;

        public Account(string personName,List<TransactionDetails> transactionList,int amountBorrowed,int amountlent){
            PersonName = personName;
            TransactionList = transactionList;
            AmountBorrowed = amountBorrowed;
            AmountLent = amountlent;
        }
    }
}