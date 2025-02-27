using Transaction;
namespace Account {
    class AccountHelper{
        public Dictionary<string,AccountDetails> ListAccounts = new Dictionary<string, AccountDetails>();

        public void CreateNewAccount(string personName){
            AccountDetails account = new AccountDetails(personName);
            ListAccounts.Add(personName,account);
        }

        public void UpdateTransactionDetailsInAccount(string personName,TransactionDetails transaction, Boolean isLender){
            AccountDetails PersonAccount = ListAccounts[personName];
            PersonAccount.addTransaction(transaction, isLender);
        }
       
        public Boolean IsAccountAvailableForUser(string person) {
            return ListAccounts.ContainsKey(person);
        }
    }
}