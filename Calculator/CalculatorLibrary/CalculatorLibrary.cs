using System;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;

namespace CalculatorLibrary
{
    //class created to seperate the calculator functionality from UI functionality
    //calculator functionality is defined in below class Calculator
    public class Calculator
    {
        JsonWriter writer;

        //default constructor
        //The idea is to create a json file
        // this will be stored in Calculator/bin/Debug/netcoreapp3.1/calculatorlog.json
        public Calculator()
        {
            StreamWriter logFile = File.CreateText("calculatorlog.json");
            logFile.AutoFlush = true;
            writer = new JsonTextWriter(logFile);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartObject();
            writer.WritePropertyName("Operations");
            writer.WriteStartArray();
        }

        //function that takes two operands (double) and a string for operator code
        public double performCalculation(double first, double second, string option)
        {
            // intialising result to Nan
            double result = Double.NaN;

            //filling the json with passed arguments
            writer.WriteStartObject();
            writer.WritePropertyName("Operand1");
            writer.WriteValue(first);
            writer.WritePropertyName("Operand2");
            writer.WriteValue(second);
            writer.WritePropertyName("Operation");

            //switch
            switch (option)
            {
                case "a":
                    // perform addition
                    result = first + second;
                    writer.WriteValue("Add");
                    break;
                case "s":
                    //perform subtraction
                    result = first - second;
                    writer.WriteValue("Subtract");
                    break;
                case "m":
                    //perform multiplication
                    result = first * second;
                    writer.WriteValue("Multiply");
                    break;
                case "d":
                    //check for division by zero error
                    if (second != 0)
                    {
                        //perform division
                        result = first / second;
                    }
                    writer.WriteValue("Divide");
                    break;
                default:
                    //return default 
                    break;
            }

            writer.WritePropertyName("Result");
            // if result is valid add result to json else add error to json
            if (isValidDouble(result)) { 
                // writing the result to json object
                writer.WriteValue(result);
            }
            else
            {
                writer.WriteValue("Error");
            }
            writer.WriteEndObject();

            return result;
        }


        // function to check if a double entered is valid
        public bool isValidDouble(double val)
        {
            return !Double.IsNaN(val) && !Double.IsInfinity(val);
        }

        // funtion to print operator codes
        public void printOptions()
        {
            Console.WriteLine("===========================================");
            Console.WriteLine("Please enter one of the following options :");
            Console.WriteLine("Enter 'a' for addition");
            Console.WriteLine("Enter 's' for subtraction");
            Console.WriteLine("Enter 'm' for multiplication");
            Console.WriteLine("Enter 'd' for division");
        }


        // this function is needed to finish the JSON syntax once the user is done entering operation data
        //this will be called once the user is out of the while loop
        public void Finish()
        {
            writer.WriteEndArray();
            writer.WriteEndObject();
            writer.Close();
        }
    }
}
