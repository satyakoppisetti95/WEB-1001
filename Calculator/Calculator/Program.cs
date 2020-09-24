using System;
using System.Linq;

namespace Calculator
{
    //class created to seperate the calculator functionality from UI functionality
    //calculator functionality is defined in below class Calculator
    class Calculator
    {

        //function that takes two operands (double) and a string for operator code
        public static double performCalculation(double first,double second,string option)
        {
            // intialising result to Nan
            double result = Double.NaN;

            //switch
            switch (option)
            {
                case "a":
                    // perform addition
                    result = first + second;
                    break;
                case "s":
                    //perform subtraction
                    result = first - second;
                    break;
                case "m":
                    //perform multiplication
                    result = first * second;
                    break;
                case "d":
                    //check for division by zero error
                    if(second != 0)
                    {
                        //perform division
                        result = first / second;
                    }
                    break;
                default:
                    //return default 
                    break;    
            }

            return result;
        }


        // function to check if a double entered is valid
        public static bool isValidDouble(double val)
        {
            return !Double.IsNaN(val) && !Double.IsInfinity(val);
        }

        // funtion to print operator codes
        public static void printOptions()
        {
            Console.WriteLine("===========================================");
            Console.WriteLine("Please enter one of the following options :");
            Console.WriteLine("Enter 'a' for addition");
            Console.WriteLine("Enter 's' for subtraction");
            Console.WriteLine("Enter 'm' for multiplication");
            Console.WriteLine("Enter 'd' for division");
        }
    }

    // main class
    //the following class handles the UI functionality
    class Program
    {
        static void Main(string[] args)
        {
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
                while (!Calculator.isValidDouble(operand_1)){
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
                while (!Calculator.isValidDouble(operand_2))
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
                    Calculator.printOptions();
                    Console.Write("Type the code for operator from options shown above, and then press Enter: ");
                    op = Console.ReadLine();
                }

                //performing calcualtion
                double result = Calculator.performCalculation(operand_1, operand_2, op);

                //checking if result is not null and printing
                if (Double.IsNaN(result))
                {
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
        }
    }
}
