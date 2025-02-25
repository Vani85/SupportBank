namespace SupportBank.Transaction {
    class TransactionDetails {
         public DateTime TransactionDate {get;}
         public string TransactionFromPerson {get;}
         public string TransactionToPerson {get;}
         public string ActivityName {get;}
         public int TransactionAmount {get;}

        public TransactionDetails(DateTime transactionDate, string transactionFromPerson, string transactionToPerson,
        string activityName, int transactionAmount)
        {
            TransactionDate = transactionDate;
            TransactionFromPerson = transactionFromPerson;
            TransactionToPerson = transactionToPerson;
            ActivityName = activityName;
            TransactionAmount = transactionAmount;
        }   

    }
}