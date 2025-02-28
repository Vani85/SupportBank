using System.Globalization;
using Microsoft.VisualBasic;


namespace Utils{
    class Utility {
        public static int MoneyConverterStringToInt(string amount)   {           
            return Convert.ToInt32(float.Parse(amount) * 100);  
        }

        public static float MoneyConverterStringToFloat(string amount)  { 
            return float.Parse(amount);          
        }
        public static DateTime DateConverterStringToDate(string date) {  
            return Convert.ToDateTime(date);     
        }
    }
}

