namespace Utils{
    class Utility {
        public static int MoneyConverterStringToInt(string amount) {
            return Convert.ToInt32(float.Parse(amount));   
        }
        public static DateTime DateConverterStringToDate(string date){
            return DateTime.ParseExact(date, "dd/MM/yyyy", null);
        }
    }
}