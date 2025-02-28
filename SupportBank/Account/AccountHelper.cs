using Transaction;
using NLog;
using Logging;


namespace Account {
    class AccountHelper{
         private static readonly ILogger Logger = LogManager.GetLogger("File Logger");
        public Dictionary<string,AccountDetails> ListAccounts = new Dictionary<string, AccountDetails>();

        public void CreateNewAccount(string personName){
            Logger.Info("Creating a new account for "+personName+ " as there is no available account");
            AccountDetails account = new AccountDetails(personName);
            ListAccounts.Add(personName,account);
            Logger.Info("New account created for "+personName);
        }

        public void UpdateAccounts(List<TransactionDetails> transactionList){
            foreach (var transaction in transactionList){
                string from = transaction.FromAccount;
                string to = transaction.ToAccount; 

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
            Logger.Info("Updating the transaction details for "+personName);
            PersonAccount.addTransaction(transaction, isLender);
            Logger.Info("Transaction Details successfully updated for "+personName);
        }
       
        private Boolean IsAccountAvailableForUser(string person) {
            return ListAccounts.ContainsKey(person);
        }
    }
}