using Transaction;
namespace Account {
    class AccountHelper{
        public static Dictionary<string,AccountDetails> ListAccounts = new Dictionary<string, AccountDetails>();

        public static void CreateNewAccount(string personName){
            AccountDetails account = new AccountDetails(personName);
            ListAccounts.Add(personName,account);
        }

        public static void UpdateTransactionDetailsInAccount(string personName,TransactionDetails transactionList,int amountBorrowed,int amountLent){
            AccountDetails PersonAccount = ListAccounts[personName];
            PersonAccount.GetTransactionDetails().Add(transactionList);
            PersonAccount.updateAmount(amountBorrowed, amountLent);            
        }

        public static Boolean IsAccountAvailableForUser(string person) {
            return ListAccounts.ContainsKey(person);
        }
    }
}