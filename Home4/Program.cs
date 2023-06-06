using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home4
{
    internal class Program
    {
        class Passport
        {
            public string Number { get; private set; }
            public string FullName { get; private set; }
            public DateTime DateOfIssue { get; private set; }

            public Passport(string number, string fullName, DateTime dateOfIssue)
            {
                if (string.IsNullOrEmpty(number))
                {
                    throw new ArgumentException("Номер паспорта не может быть пустым.");
                }

                if (string.IsNullOrEmpty(fullName))
                {
                    throw new ArgumentException("ФИО владельца не может быть пустым.");
                }

                if (dateOfIssue.Year < 1900 || dateOfIssue > DateTime.Now)
                {
                    throw new ArgumentException("Некорректная дата выдачи паспорта.");
                }

                Number = number;
                FullName = fullName;
                DateOfIssue = dateOfIssue;
            }
        }
        static void Main(string[] args)
        {
            /*Console.WriteLine("Выберите направление перевода:" +
                "\n1. Из десятичной в двоичную"+
                "\n2. Из двоичной в десятичную\"");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    DecimalToBinary();
                    break;
                case 2:
                    BinaryToDecimal();
                    break;
                default:
                    Console.WriteLine("Неправильный выбор.");
                    break;
            }*/

            /* Console.Write("Введите слово от 0 до 9: ");
            string word = Console.ReadLine();

            int number;
            switch (word)
            {
                case "ноль":
                    number = 0;
                    break;
                case "один":
                    number = 1;
                    break;
                case "два":
                    number = 2;
                    break;
                case "три":
                    number = 3;
                    break;
                case "четыре":
                    number = 4;
                    break;
                case "пять":
                    number = 5;
                    break;
                case "шесть":
                    number = 6;
                    break;
                case "семь":
                    number = 7;
                    break;
                case "восемь":
                    number = 8;
                    break;
                case "девять":
                    number = 9;
                    break;
                default:
                    Console.WriteLine("Ошибка: введено некорректное слово.");
                    return;
            }

            Console.WriteLine(number);*/
            /*Console.Write("Введите логическое выражение: ");
            string expression = Console.ReadLine();

            try
            {
                bool result = EvaluateExpression(expression);
                Console.WriteLine("Результат: " + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }*/
            DateTime dateTime= DateTime.Now;
            Passport pass = new Passport("78227","ivanov ivan",dateTime);
        }
        static bool EvaluateExpression(string expression)
        {
            int leftOperand = 0;
            int rightOperand = 0;
            string op = "";

            string[] tokens = expression.Split(' ');
            if (tokens.Length != 3)
            {
                throw new Exception("Некорректное выражение.");
            }

            if (!int.TryParse(tokens[0], out leftOperand) || !int.TryParse(tokens[2], out rightOperand))
            {
                throw new Exception("Выражение должно содержать только целые числа.");
            }

            op = tokens[1];
            switch (op)
            {
                case "<":
                    return leftOperand < rightOperand;
                case ">":
                    return leftOperand > rightOperand;
                case "<=":
                    return leftOperand <= rightOperand;
                case ">=":
                    return leftOperand >= rightOperand;
                case "==":
                    return leftOperand == rightOperand;
                case "!=":
                    return leftOperand != rightOperand;
                default:
                    throw new Exception("Некорректный оператор.");
            }
        }
        static void DecimalToBinary()
        {
            Console.Write("Введите десятичное число: ");
            int decimalNumber = int.Parse(Console.ReadLine());

            if (decimalNumber < 0)
            {
                Console.WriteLine("Ошибка: введено отрицательное число.");
                return;
            }

            int quotient = decimalNumber;
            string binaryString = "";

            while (quotient > 0)
            {
                int remainder = quotient % 2;
                binaryString = remainder.ToString() + binaryString;
                quotient = quotient / 2;
            }

            Console.WriteLine("Двоичное представление: " + binaryString);
        }
        static void BinaryToDecimal()
        {
            Console.Write("Введите двоичное число: ");
            string binaryString = Console.ReadLine();

            if (!IsBinaryString(binaryString))
            {
                Console.WriteLine("Ошибка: введено некорректное двоичное число.");
                return;
            }

            int decimalNumber = 0;
            int power = 0;

            for (int i = binaryString.Length - 1; i >= 0; i--)
            {
                if (binaryString[i] == '1')
                {
                    decimalNumber += (int)Math.Pow(2, power);
                }
                power++;
            }

            Console.WriteLine("Десятичное представление: " + decimalNumber);
        }
        static bool IsBinaryString(string str)
        {
            foreach (char c in str)
            {
                if (c != '0' && c != '1')
                {
                    return false;
                }
            }
            return true;
        }
    }
 
}
