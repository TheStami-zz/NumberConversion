using System;
using System.Collections.Generic;

namespace A15.Math.Conversion {
    public class NumberConversion {
        private static readonly char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        public static string Convert(uint baseSystem, uint destinationSystem, string number) =>
            Convert(System.Convert.ToInt32(baseSystem), System.Convert.ToInt32(destinationSystem), number);
        private static string Convert(int baseSystem, int destinationSystem, string number) {
            if(baseSystem == 0 || destinationSystem == 0)
                throw new ArgumentException("Number System connot be zero");
            if(number == "0") 
                return "0";
            if(baseSystem == destinationSystem)
                return number.ToString();

            long decimalNumber;
            if(baseSystem != 10)
                decimalNumber = ConvertToDecimal(baseSystem, number);
            else
                decimalNumber = System.Convert.ToInt32(number);

            if(destinationSystem != 10)
                return ConvertFromDecimalToAny(decimalNumber, destinationSystem);
            else 
                return decimalNumber.ToString();
        }

        private static long ConvertToDecimal(int baseSystem, string number) {
            string numbers = number.ToString();
            long[] heavyNumbers = new long[numbers.Length];

            int i = 0;
            int p = numbers.Length - 1;

            while(i < numbers.Length) {
                Console.WriteLine(baseSystem + "^" + p  + " --> " + System.Math.Pow(baseSystem, p) + " * " + numbers[i].ToString());
                heavyNumbers[i] = System.Convert.ToInt64(System.Math.Pow(baseSystem, p)) * System.Convert.ToInt64(numbers[i].ToString());
                
                i++;
                p--;
            }

            long decimalNumber = 0;
            for(int s = 0; s < heavyNumbers.Length; s++) {
                decimalNumber += heavyNumbers[s];
            }

            return decimalNumber;
        }

        private static string ConvertFromDecimalToAny(long decimalNumber, int destinationSystem) {
            List<long> rest = new List<long>();
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
