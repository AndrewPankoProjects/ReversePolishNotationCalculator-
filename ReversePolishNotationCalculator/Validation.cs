/*
 * I, Andrew Panko, 000394436, 
 * certify that all code submitted is my own work; 
 * that I have not copied it from any other source. 
 * I also certify that I have not allowed my work to be copied by others.
 * 
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Assignment1
{
    public class Validation
    {
        List<string> ListOfValues = new List<string>();
        delegate bool IsOperandOrOperator(string i);
        int KeepTrackOfStack = 0;
        
        /// <summary>
        /// Method takes in user's input expression called "StringExpression" as well
        /// a parameter "IsValid" used as a flag if the expression is valid
        /// </summary>
        /// <param name="StringExpression"></param>
        /// <param name="isValid"></param>
        /// <returns></returns>
        public bool IsValid(string StringExpression, bool IsValid)
        {
            //Checks the token for the follow operators or operands
            foreach (var Token in StringExpression.Split(' '))
            {
                if (Regex.IsMatch(Token, @"[0-9]") || 
                      Regex.IsMatch(Token, @"[*]") || 
                      Regex.IsMatch(Token, @"[-]") || 
                      Regex.IsMatch(Token, @"[/]") || 
                      Regex.IsMatch(Token, @"[+]"))
                {
                    //Checks for operator
                    if (double.TryParse(Token, out var result))
                    {
                        KeepTrackOfStack--;
                    }
                    //Otherwise operand
                    else
                    {
                        KeepTrackOfStack++;
                    }
                }
                //If the token is neither operator or operand specified stop checking
                else
                {
                    IsValid = false; break;
                }
            }
            //Checking stack is empty means expression is invalid
            if (KeepTrackOfStack <= 0)
            {
                IsValid = false;
            }
            //Checking stack is equal to one expression which is valid
            else if(KeepTrackOfStack == 1)
            {
                IsValid = true;
            }
            //Any other unknown size is invalid
            else
            {
                IsValid = false;
            }
            
            //Displays expression invalid 
            while (!IsValid)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n{StringExpression} is not a valid Reverse Polish Notation expression, please enter a valid expression");
                Console.ResetColor();
                return false;
            }
            return true;
        } 

            
            
    }
}

