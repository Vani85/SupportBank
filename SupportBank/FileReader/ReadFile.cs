using System.Data;
using Transaction;
using Utils;
using NLog;
using Logging;


namespace FileReader {
    class ReadFile {
        private static readonly ILogger Logger = LogManager.GetLogger("File Logger");
     
        public static string[] GetListOfAllFiles (){
            string FolderPath = Directory.GetCurrentDirectory()+"\\FileReader\\Input_Files";
            string [] FileList = Directory.GetFiles(FolderPath);
            return FileList;
        }
        public static List<TransactionDetails> ReadTransactionDetailsFromCsvFile(string FilePath) {
            List<TransactionDetails> transactions = new List<TransactionDetails>();
            string FileName = Path.GetFileName(FilePath);
            Logger.Info("Reading File: "+ FileName +"........");
            try {
                using(var reader = new StreamReader(@FilePath))
                {
                    int index = 0;
                    while (!reader.EndOfStream)
                    {
                        try{
                            var line = reader.ReadLine();
                            var values = line?.Split(',');
                            if(index != 0) {
                                TransactionDetails transaction = new TransactionDetails(
                                    Utility.DateConverterStringToDate(values[0].Trim()), 
                                    values[1].Trim(),
                                    values[2].Trim(),
                                    values[3].Trim(), 
                                    Utility.MoneyConverterStringToInt(values[4].Trim()));
                                transactions.Add(transaction);
                            }
                            index++;  
                        }catch(System.FormatException exception){
                            Logger.Error("Error occurred at line " + index + " of file : " + FileName + " : " + exception.Message);
                        }     
                    }

                } 
                Logger.Info(FileName+" read successfully and transactions captured");   
            }catch(FileNotFoundException exception){
                Logger.Error("Error occured while reading the file :" + FileName +" : "+exception.Message);                
            }               
            
            return transactions;    
        }
    }        
}
