using FileReader;
using SupportBank.Transaction;
using SupportBank.Account;

namespace SupportBank {
    class SupportBank {
        public static Dictionary<string,AccountDetails> ListAccounts = new Dictionary<string, AccountDetails>();
        public static void Main() {
            List<TransactionDetails> transactions = ReadFile.ReadTransactionDetailsFromCsvFile();
            Console.WriteLine("Count - " + transactions.Count());
            foreach (var transaction in transactions)
            {
                string from = transaction.TransactionFromPerson;
                string to = transaction.TransactionToPerson;
                DateTime date = transaction.TransactionDate;
                string activity = transaction.ActivityName;
                int amount = transaction.TransactionAmount;

                if(ListAccounts.ContainsKey(from) && ListAccounts.ContainsKey(to)) {
                    //Update From Account
                    AccountDetails PersonAccount = ListAccounts[from];
                    PersonAccount.GetTransactionDetails().Add(new TransactionDetails(date,from,to,activity,amount));
                    PersonAccount.updateAmountLent(amount);

                    //Update To Account
                    PersonAccount = ListAccounts[to];
                    PersonAccount.GetTransactionDetails().Add(new TransactionDetails(date,from,to,activity,amount));
                    PersonAccount.updateAmountBorrowed(amount);                     
                    
                } else {                            
                    List<TransactionDetails> ListTransaction = new List<TransactionDetails>();
                    ListTransaction.Add(new TransactionDetails(date,from,to,activity,amount));

                    if(!ListAccounts.ContainsKey(from)){
                        //Add From Account
                        AccountDetails account = new AccountDetails(from,ListTransaction);
                        account.updateAmountLent(amount);
                        ListAccounts.Add(from,account);
                    }
                    else{
                        //Update From Account
                        AccountDetails PersonAccount = ListAccounts[from];
                        PersonAccount.GetTransactionDetails().Add(new TransactionDetails(date,from,to,activity,amount));
                        PersonAccount.updateAmountLent(amount);
                    }

                    if(!ListAccounts.ContainsKey(to)){
                        //Add To account
                        AccountDetails account = new AccountDetails(to,ListTransaction);
                        account.updateAmountBorrowed(amount);
                        ListAccounts.Add(to,account);
                    }
                    else{
                         //Update To Account
                        AccountDetails PersonAccount = ListAccounts[to];
                        PersonAccount.GetTransactionDetails().Add(new TransactionDetails(date,from,to,activity,amount));
                        PersonAccount.updateAmountBorrowed(amount);       
                    }                
                    
                }
                

                Console.WriteLine(transaction.TransactionDate + "," + transaction.TransactionFromPerson + "," 
                + transaction.TransactionToPerson + "," + transaction.ActivityName 
                + "," + transaction.TransactionAmount);

            }

             foreach (var accounts in ListAccounts.Values)
            {
                Console.WriteLine(" =============================  ");
                Console.WriteLine(accounts.PersonName);
                Console.WriteLine(accounts.AmountLent);
                Console.WriteLine(accounts.AmountBorrowed);
                foreach(var transaction in accounts.GetTransactionDetails()) {
                    Console.WriteLine(transaction.TransactionFromPerson 
                    + " --  " + transaction.TransactionToPerson 
                    + " --  " + transaction.TransactionAmount 
                     + " --  " + transaction.ActivityName
                    + " --  " + transaction.TransactionDate);
                    
                }

                Console.WriteLine(" =============================  ");
            }

        }
    }
}