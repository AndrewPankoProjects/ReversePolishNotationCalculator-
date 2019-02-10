/* Your name and student number: Andrew Panko, 000394436
 * 
 * The file date: Feb. 8th, 2019 1:50PM
 * 
 * I, Andrew Panko, 000394436, 
 * certify that all code submitted is my own work; 
 * that I have not copied it from any other source. 
 * I also certify that I have not allowed my work to be copied by others.
 * 
 */
using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Collections;

namespace Assignment1
{
    public class Program
    {
        private static void Main(string[] args)
        {
            //Initialized objects and variables
            BinaryExpression ExpressionTree = null;
            bool IsValidExpression = false;
            bool ResultIsValid = false;
            MyExpressionVisitor myExpressionVisitor = new MyExpressionVisitor();
            Validation ValidateInput = new Validation();
            CalculateExpression GoToCalculation = new CalculateExpression();

            //Prompts the user until valid expression
            do
            {
                var StringExpression = GoToCalculation.PromptUser();
                
                ResultIsValid = ValidateInput.IsValid(StringExpression, IsValidExpression);

                //Each character in the expression is being validated one at a time
                if (ResultIsValid)
                {
                    ExpressionTree = GoToCalculation.CalculateValidExpression(StringExpression, ExpressionTree, myExpressionVisitor);

                    try
                    {
                        var results = Expression.Lambda(ExpressionTree).Compile().DynamicInvoke();

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"The Reverse Polish Notation of this expression is: {results:f}");
                        Console.ResetColor();

                        IsValidExpression = true;
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\n{StringExpression} is NOT a valid Reverse Polish Notation expression, please enter a valid expression");
                        Console.ResetColor();
                        IsValidExpression = false;
                    }
                }
            } while (!IsValidExpression);

            Console.ReadKey();
        }
    }
}
