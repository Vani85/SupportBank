using Account;
namespace Reports{
    class ReportGenerator{

        public static void GenerateReport() {            
            Console.WriteLine("Enter 1 : To see list of Accounts");
            Console.WriteLine("Enter 2 : To see transaction details for a user");
            int userChoice = 0;
            userChoice = Convert.ToInt32(Console.ReadLine());
            if (userChoice == 1){
                ListAllTransactions(AccountHelper.ListAccounts);
            }
            else if(userChoice == 2){
                Console.WriteLine("Enter full name of the user");
                string username = Console.ReadLine();
                PrintTransactionDetailsPerAccount(AccountHelper.ListAccounts,username);
            }
            else {
                Console.WriteLine("Please enter 1 0r 2 only");
            }

        }

        public static void ListAllTransactions(Dictionary<string,AccountDetails>ListAccounts){
            Console.WriteLine(" ======================List of All Account Details ======================");   
            Console.WriteLine("+-----------------+-----------------+-----------------+-----------------+");
            Console.WriteLine("| {0,-12} | {1,-20} | {2,-20} |", "Name", "Amount Lent (£)", "Amount Borrowed(£)");
            Console.WriteLine("+-----------------+-----------------+-----------------+-----------------+");
                  
             foreach (var accounts in ListAccounts.Values){
                Console.WriteLine("| {0,-12} | {1,-20} | {2,-20} |", 
                    accounts.PersonName,
                    (float)accounts.AmountLent/100,
                    (float)accounts.AmountBorrowed/100);             
            }
             Console.WriteLine("+-----------------+-----------------+-----------------+-----------------+");
        }
        public static void PrintTransactionDetailsPerAccount(Dictionary<string,AccountDetails>ListAccounts,string userName){
            AccountDetails accounts = ListAccounts[userName];
            Console.WriteLine(" =============================== Transactions for "+ accounts.PersonName +"==============================");

            Console.WriteLine("+-----------------+-----------------+-----------------+-----------------+-----------------+");
            Console.WriteLine("| {0,-12} | {1,-12} | {2,-10} | {3,-20} | {4,-10} |", "From", "To", "Amount (£)","Activity Name","Date");
            Console.WriteLine("+-----------------+-----------------+-----------------+-----------------+-----------------+");
            foreach(var transaction in accounts.GetTransactionDetails()) {

                Console.WriteLine("| {0,-12} | {1,-12} | {2,-10} | {3,-20} | {4,-10} |", 
                    transaction.TransactionFromPerson, 
                    transaction.TransactionToPerson ,
                    (float)transaction.TransactionAmount/100, 
                    transaction.ActivityName,
                    transaction.TransactionDate.ToShortDateString());
            }
            Console.WriteLine("+-----------------+-----------------+-----------------+-----------------+-----------------+");
  
        }
    }
}



       