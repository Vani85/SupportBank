using Account;
using NLog;
using Logging;


namespace Reports{
    class ReportGenerator{
        private static readonly ILogger Logger = LogManager.GetLogger("File Logger");
        public void GenerateReport(AccountHelper accountHelper) {   
            while(true) {         
                Console.WriteLine("Enter 1 : To see list of Accounts");
                Console.WriteLine("Enter 2 : To see transaction details for a user");
                Console.WriteLine("Enter 3 : Exit");
                int userChoice = 0;
                userChoice = Convert.ToInt32(Console.ReadLine());
                if (userChoice == 1){
                    ListAllTransactions(accountHelper.ListAccounts);
                }
                else if(userChoice == 2){
                    while(true) {
                        Console.WriteLine("Enter full name of the user");
                        string username = Console.ReadLine();
                        if(accountHelper.ListAccounts.ContainsKey(username)) {
                            PrintTransactionDetailsPerAccount(accountHelper.ListAccounts,username);
                            break;
                        }
                        else{
                            Logger.Error("Invalid Username");
                            Console.WriteLine("Please enter a valid username. The user is not available in our system");
                        }
                    }  
                }
                else if(userChoice == 3){
                    Environment.Exit(0);
                }
                else {
                    Logger.Error("Invalid Option");
                    Console.WriteLine("Please enter a valid option from below :");
                }
            }    
        }
    

        public void FormatListAllOutput(){
            Console.WriteLine(" ======================List of All Account Details ======================");   
            Console.WriteLine("+-----------------+-----------------+-----------------+-----------------+");
            Console.WriteLine("| {0,-12} | {1,-20} | {2,-20} |", "Name", "Amount Lent (£)", "Amount Borrowed(£)");
            Console.WriteLine("+-----------------+-----------------+-----------------+-----------------+");
        }

        public void FormatTransactionDetailsOutput(string personName){
            Console.WriteLine(" =================================== Transactions for "+ personName +"======================================");

            Console.WriteLine("+-----------------+-----------------+-----------------+-----------------+-----------------+-----------------+");
            Console.WriteLine("| {0,-12} | {1,-12} | {2,-10} | {3,-40} | {4,-10} |", "From", "To", "Amount (£)","Activity Name","Date");
            Console.WriteLine("+-----------------+-----------------+-----------------+-----------------+-----------------+-----------------+");
        }
        
        public void ListAllTransactions(Dictionary<string,AccountDetails>ListAccounts){
            FormatListAllOutput();
            Logger.Info("Listing out all transactions");
            foreach (var accounts in ListAccounts.Values){
                Console.WriteLine("| {0,-12} | {1,-20} | {2,-20} |", 
                    accounts.PersonName,
                    (float)accounts.AmountLent/100,
                    (float)accounts.AmountBorrowed/100);             
            }
             Console.WriteLine("+-----------------+-----------------+-----------------+-----------------+");
        }
        public void PrintTransactionDetailsPerAccount(Dictionary<string,AccountDetails>ListAccounts,string userName){
            AccountDetails accounts = ListAccounts[userName];
            FormatTransactionDetailsOutput(accounts.PersonName);
            Logger.Info("Listing out details for "+accounts.PersonName);
            foreach(var transaction in accounts.TransactionList) {

                Console.WriteLine("| {0,-12} | {1,-12} | {2,-10} | {3,-40} | {4,-10} |", 
                    transaction.TransactionFromPerson, 
                    transaction.TransactionToPerson ,
                    (float)transaction.TransactionAmount/100, 
                    transaction.ActivityName,
                    transaction.TransactionDate.ToShortDateString());
            }
            Console.WriteLine("+-----------------+-----------------+-----------------+-----------------+-----------------+-----------------+");
  
        }
    }
}



       