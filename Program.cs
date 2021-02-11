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

            int decimalNumber = 0;
            if(baseSystem != 10) {
                string numbers = number.ToString();
                int[] heavyNumbers = new int[numbers.Length];

                if(true) {
                    int i = 0;
                    int p = numbers.Length - 1;
                    
                    while(i < numbers.Length) {
                        heavyNumbers[i] = System.Convert.ToInt32(System.Math.Pow(baseSystem, p)) * System.Convert.ToInt32(numbers[i].ToString());
                     
                        i++;
                        p--;
                    }
                }

                for(int i = 0; i < heavyNumbers.Length; i++) {
                    decimalNumber += heavyNumbers[i];
                }
            } else {
                decimalNumber = number;
            }
            
            return decimalNumber;
        }
    }
}
