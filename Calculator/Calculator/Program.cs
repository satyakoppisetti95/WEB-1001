using System;
using System.Linq;
using CalculatorLibrary;

namespace CalculatorProgram
{
    

    // main class
    //the following class handles the UI functionality
    class Program
    {
        static void Main(string[] args)
        {

            //initialising calculator object
            Calculator calculator = new Calculator();

            // we declare a boolen for while loop.
            // At the end of calculation we ask user for more inputs or close application
            // if the user wishes to close application. endLoop witll be set to true and while loop will break
            bool endLoop = false;

            Console.WriteLine("Welcome to C# Calculator\n");
            Console.WriteLine("========================\n");

            //looping as explained above
            while (!endLoop)
            {
                //initialising both operands to Nan
                //the idea is to loop asking the input from user till the operand recieves a valid input
                double operand_1 = Double.NaN;
                double operand_2 = Double.NaN;

                //initialising operators
                // a - addition
                // s - subtraction
                // m - multiplication
                // d - division
                string op = "z";
                string [] operators = { "a", "s", "m", "d" };

                //looping through, till the user enters a valid operand
                while (!calculator.isValidDouble(operand_1)){
                    Console.Write("Type a valid first operand, and then press Enter: ");
                    try
                    {
                        operand_1 = Convert.ToDouble(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Oops! invalid number.");
                    }
                }

                //looping through, till the user enters a valid operand
                while (!calculator.isValidDouble(operand_2))
                {
                    Console.Write("Type a valid second operand, and then press Enter: ");
                    try
                    {
                        operand_2 = Convert.ToDouble(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Oops! invalid number.");
                    }
                }

                //looping thorugh till the user enters a valid operator code
                while (!operators.Contains(op))
                {
                    calculator.printOptions();
                    Console.Write("Type the code for operator from options shown above, and then press Enter: ");
                    op = Console.ReadLine();
                }

                //performing calcualtion
                double result = calculator.performCalculation(operand_1, operand_2, op);

                //checking if result is not null and printing results
                if (Double.IsNaN(result))
                {
                    Console.WriteLine("======================================");
                    Console.WriteLine("Oops! Looks like there is a mathematical error. Please enter valid numbers for choosen operation");
                }
                else
                {
                    Console.WriteLine("======================================");
                    Console.WriteLine("Result : {0:0.##}\n", result);
                    Console.WriteLine("");
                }

                //asking the user if he wishes to quit or continue
                Console.WriteLine("Press 'q' and enter to exit or any other key to continue.");
                if (Console.ReadLine() == "q") endLoop = true;


            }

            calculator.Finish();
            return;
        }
    }
}
