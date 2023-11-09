namespace MyDiary
{
    partial class Program
    {
        public static class Functions
        {
            public static string Sal(int sal, string county)
            {
                decimal rate = 0.0M;
                switch (county)
                {
                    case "bromma":
                        rate = 0.29M;
                        break;
                    case "solna":
                        rate = 0.31M;
                        break;
                    case "Stockholms":
                        rate = 0.32M;
                        break;
                    default: 
                        rate = 0.30M;
                        break;
                }
               
                int calculatedValue = sal - (int)(sal * rate);
                return $"Salary: {sal}, County: {county}, Tax rate: {rate}, Final salarys: {calculatedValue}";
            }
            // public static void PrintMessage(string message)
            // {
            //     Console.WriteLine(message);
            // }
        }
    }
}
