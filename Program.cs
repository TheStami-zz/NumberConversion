using System;

namespace A15.Math.Convertion {
    class NumberConvertion {
        static void Main(string[] args) {
            Console.WriteLine(Convert(2, 0, 110));
        }

        public static int Convert(int baseSystem, int destinationSystem, int number) {
            int a = number;
            int m = baseSystem;
            int n = destinationSystem;

            int decimalNumber;
            if(baseSystem != 10)
                decimalNumber = ConvertToDecimal(baseSystem, number);
            else
                decimalNumber = number;
            
            return decimalNumber;
        }

        private static int ConvertToDecimal(int baseSystem, int number) {
            string numbers = number.ToString();
            int[] heavyNumbers = new int[numbers.Length];

            int i = 0;
            int p = numbers.Length - 1;

            while(i < numbers.Length) {
                heavyNumbers[i] = System.Convert.ToInt32(System.Math.Pow(baseSystem, p)) * System.Convert.ToInt32(numbers[i].ToString());
                
                i++;
                p--;
            }

            int decimalNumber = 0;
            for(int s = 0; s < heavyNumbers.Length; s++) {
                decimalNumber += heavyNumbers[s];
            }

            return decimalNumber;
        }
    }
}
