using System.Data;

namespace SupportBank.fileReader {
    class FileReader {
        public static string FileName = "Transactions2014.csv";
        public static DataTable ReadCsvFile() {
            DataTable fileContent = new DataTable("DataTable");
            using(var reader = new StreamReader(@"./fileReader/"+FileName))
            {
                int index = 0;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line?.Split(',');
                    if(index == 0) {
                        fileContent.Columns.Add(values[0], typeof(string));
                        fileContent.Columns.Add(values[1], typeof(string));
                        fileContent.Columns.Add(values[2], typeof(string));
                        fileContent.Columns.Add(values[3], typeof(string));
                        fileContent.Columns.Add(values[4], typeof(string));
                        index++;
                    }
                    fileContent.Rows.Add(values[0], values[1], values[2],values[3],values[4]);
                }
            }      
            return fileContent;      
        }
    }        
}
