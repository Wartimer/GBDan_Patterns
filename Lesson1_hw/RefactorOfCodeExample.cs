using System;
using System.Numerics;
using System.Runtime.Hosting;
using System.Text;

namespace Patterns_HomeWork1
{
    internal class RefactorOfCodeExample
    {
        public static void Main(string[] args)
        {
            var texts = new TextsContainer();
            var printer = new Printer();
            var calculator = new Calculator();
            var inputHandler = new InputHandler(texts, printer);
            
            printer.PrintText(texts[0]);
            inputHandler.ReadInput();

            if (inputHandler.Input == "q") return;

            calculator.Calculate(inputHandler.Number);
            printer.PrintResults(texts, calculator);
        }
    }

    internal sealed class Calculator
    {
        private BigInteger _factNumber = 1; 
        private int _sum = 0;
        private int _maxEvenNumber = 0;

        internal BigInteger FactNumber => _factNumber;
        internal int Sum => _sum;
        internal int MaxEvenNumber => _maxEvenNumber;

        internal void Calculate(int number)
        {
            for (int i = 1; i <= number; i++)
            {
                _factNumber *= i;
                _sum += i;
                if (i%2 == 0) _maxEvenNumber = i;
            }
        }
    }

    internal sealed class InputHandler
    {
        private int _number;
        private string _input;
        private TextsContainer _textsContainer;
        private Printer _printer;

        public int Number => _number;
        public string Input => _input;

        internal InputHandler(TextsContainer textsContainer, Printer printer)
        {
            _textsContainer = textsContainer;
            _printer = printer;
        }
        
        internal void ReadInput()
        {
            while (true)
            {
                string input = Console.ReadLine();
                int number = 0;
                if (input == "q")
                {
                    _input = input;
                    return;
                }
                
                if (!Int32.TryParse(input, out number))
                {
                    _printer.PrintText(_textsContainer[1]);
                }
                else
                {
                    _number = number;
                    break;
                }
            }
        }
    }

    internal sealed class Printer
    {
        internal void PrintText(string text)
        {
            Console.WriteLine(text);
        }

        internal void PrintResults(TextsContainer texts, Calculator calculator)
        {
            Console.WriteLine($"{texts[2]} {calculator.FactNumber}\n" +
                              $"{texts[3]} {calculator.Sum}\n" +
                              $"{texts[4]} {calculator.MaxEvenNumber}");
            Console.ReadLine();
        }
    }

    internal sealed class TextsContainer
    {
        private string[] _texts;

        internal TextsContainer()
        {
            _texts = new string[5];
            _texts[0] = "Здравствуйте вас приветствует математическая программа \n" +
                        "пажалуйста введите число.";
            _texts[1] = "Введите целое число: \n";
            _texts[2] = "Факториал равен ";
            _texts[3] = "Сума от 1 до N равна ";
            _texts[4] = "максимальное четное число меньше N равно ";
        }
        internal string this[int i] => _texts[i];
    }
}