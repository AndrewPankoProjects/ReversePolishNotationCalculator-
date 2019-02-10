using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    public class CalculateExpression
    {
        /// <summary>
        /// Prompts user for expression to enter
        /// </summary>
        /// <returns></returns>
        public string PromptUser()
        {            
            Console.WriteLine("Welcome to Reverse Polish Notation");
            Console.WriteLine("Please enter an expression...(Include spaces)");
            var stringExpression = Console.ReadLine();
            return stringExpression;
        }

        /// <summary>
        /// This method takes in parameters after validation is complete
        /// Of ValidExpression, ExpressionTree, And using MyExpressionVisitor Class
        /// This allows the ExpressionTree Variable to access the MyExpressionVisitor class
        /// To add to the stack of binary expressions and constants
        /// And returns the ExpressionTree complete expression
        /// </summary>
        /// <param name="ValidExpression"></param>
        /// <param name="ExpressionTree"></param>
        /// <param name="myExpressionVisitor"></param>
        /// <returns></returns>
        public BinaryExpression CalculateValidExpression(string ValidExpression, BinaryExpression ExpressionTree, MyExpressionVisitor myExpressionVisitor)
        {
            foreach (var token in ValidExpression.Split(' '))
            {
                //Checks for operand
                if (double.TryParse(token, out var result))
                {
                    ExpressionTree = (BinaryExpression)myExpressionVisitor.Visit(Expression.Constant(result));
                }
                //Operator otherwise
                else
                {
                    ExpressionTree = (BinaryExpression)myExpressionVisitor.Visit(Expression.Constant(token));
                }
            }
            return ExpressionTree;
        }
        
    }
}
