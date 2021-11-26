using System;
using System.Numerics;

namespace Patterns_HomeWork1
{
    internal class RefactorOfCodeExample
    {
        public static void Main(string[] args)
        {
            
            Console.WriteLine("Здравствуйте вас приветствует математическая программа \n" +
                              "пажалуйста введите число.");
            
            int number = 0;
            
            while (true)
            {
                string input = Console.ReadLine();
                
                if (input == "q") return;
                
                if (!Int32.TryParse(input, out number))
                {
                    Console.Write("Введите целое число: \n");
                }
                
                else break;
            }

            var calculator = new Calculator(number);
            calculator.Calculate();
            
            Console.WriteLine(calculator.ToString());
            Console.ReadLine();
        }
    }

    internal sealed class Calculator
    {
        private int _number;
        BigInteger _factNumber = 1; 
        int _sum = 0;
        int _maxEvenNumber = 0;

        internal Calculator(int number)
        {
            _number = number;
        }

        internal void Calculate()
        {
            for (int i = 1; i <= _number; i++)
            {
                _factNumber *= i;
                _sum += i;
                if (i%2 == 0) _maxEvenNumber = i;
            }
        }
        
        public override string ToString()
        {
            return $"Факториал равен {_factNumber}\n" +
                   $"Сума от 1 до N равна {_sum}\n" +
                   $"максимальное четное число меньше N равно {_maxEvenNumber}";
        }
    }
}