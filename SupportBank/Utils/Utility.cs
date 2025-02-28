using System.Globalization;
using Microsoft.VisualBasic;


namespace Utils{
    class Utility {
        public static int MoneyConverterStringToInt(string amount)  {
            try {
                return Convert.ToInt32(float.Parse(amount) * 100);   
            } catch(System.FormatException) {
                throw;
            }
        }
        public static DateTime DateConverterStringToDate(string date) {  
            try {
                return DateTime.ParseExact(date, "dd/MM/yyyy", null).Date;  
            } catch(System.FormatException) {
                throw;
            }
        }
    }
}

