using Transaction;
namespace Account {
    class AccountHelper{
        public Dictionary<string,AccountDetails> ListAccounts = new Dictionary<string, AccountDetails>();

        public void CreateNewAccount(string personName){
            AccountDetails account = new AccountDetails(personName);
            ListAccounts.Add(personName,account);
        }

        public void UpdateAccounts(List<TransactionDetails> transactionList){
            foreach (var transaction in transactionList){
                string from = transaction.TransactionFromPerson;
                string to = transaction.TransactionToPerson; 

                if(!IsAccountAvailableForUser(from)){
                    CreateNewAccount(from);
                }

                if(!IsAccountAvailableForUser(to)){
                    CreateNewAccount(to);
                }
                UpdateTransactionDetailsInAccount(from,transaction,true);  
                UpdateTransactionDetailsInAccount(to,transaction,false);  
            }    
        }
        
        private void UpdateTransactionDetailsInAccount(string personName,TransactionDetails transaction, Boolean isLender){
            AccountDetails PersonAccount = ListAccounts[personName];
            PersonAccount.addTransaction(transaction, isLender);
        }
       
        private Boolean IsAccountAvailableForUser(string person) {
            return ListAccounts.ContainsKey(person);
        }
    }
}