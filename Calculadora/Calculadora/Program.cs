using System;

namespace Calculadora
{
    class Calculadora
    {
        public static double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN; 

            switch (op)
            {
                case "a":
                    result = num1 + num2;
                    break;
                case "s":
                    result = num1 - num2;
                    break;
                case "m":
                    result = num1 * num2;
                    break;
                case "d":
                    
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    break;
                
                default:
                    break;
            }
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;

            Console.WriteLine("Calculadora C#\r");
            Console.WriteLine("------------------------\n");

            while (!endApp)
            {
                
                string numInput1 = "";
                string numInput2 = "";
                double result = 0;

                
                Console.Write("Digite um numero e aperte Enter: ");
                numInput1 = Console.ReadLine();

                double cleanNum1 = 0;
                while (!double.TryParse(numInput1, out cleanNum1))
                {
                    Console.Write("Esta não é uma entrada válida. Por favor insira um valor: ");
                    numInput1 = Console.ReadLine();
                }

                Console.Write("Digite outro numero e aperte Enter: ");
                numInput2 = Console.ReadLine();

                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2))
                {
                    Console.Write("Esta não é uma entrada válida. Por favor insira um valor: ");
                    numInput2 = Console.ReadLine();
                }

                Console.WriteLine("Escolha um operador:");
                Console.WriteLine("\ta - Somar");
                Console.WriteLine("\ts - Subtrair");
                Console.WriteLine("\tm - Multiplicar");
                Console.WriteLine("\td - Dividir");
                Console.Write("Qual vai ser? ");

                string op = Console.ReadLine();

                try
                {
                    result = Calculadora.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("Esta operação resultará em um erro\n");
                    }
                    else Console.WriteLine("Total: {0:0.##}\n", result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ocorreu uma exceção ao tentar fazer a conta.\n - Detalhes: " + e.Message);
                }

                Console.WriteLine("------------------------\n");

                Console.Write("Pressione 'n' e Enter para fechar o aplicativo ou pressione qualquer outra tecla e Enter para continuar: ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n");
            }
            return;
        }
    }
}