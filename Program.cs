using System;
using System.Collections.Generic;

namespace A15.Math.Convertion {
    class NumberConvertion {
        private static readonly char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        static void Main(string[] args) {
            Console.WriteLine(Convert(18, 34, 321));
        }

        public static string Convert(int baseSystem, int destinationSystem, int number) {
            int decimalNumber;
            if(baseSystem != 10)
                decimalNumber = ConvertToDecimal(baseSystem, number);
            else
                decimalNumber = number;

            if(destinationSystem != 10)
                return ConvertFromDecimalToAny(decimalNumber, destinationSystem);
            else 
                return decimalNumber.ToString();
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

        private static string ConvertFromDecimalToAny(int decimalNumber, int destinationSystem) {
            List<int> rest = new List<int>();
            while(decimalNumber != 0) {
                rest.Add(decimalNumber % destinationSystem);
                decimalNumber = decimalNumber / destinationSystem;
            }

            string[] results = new string[rest.Count];
            for(int i = 0; i < rest.Count; i++) {
                if(rest[i] >= 10) {
                    results[i] = alpha[rest[i] - 10].ToString();
                } else {
                    results[i] = rest[i].ToString();
                }
            }

            string result = "";
            for(int i = rest.Count - 1; i >= 0; i--) {
                result += results[i];
            }

            return result;
        }
    }
}
