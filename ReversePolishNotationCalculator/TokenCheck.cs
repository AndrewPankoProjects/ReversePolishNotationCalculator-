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
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using System.Collections;


namespace Assignment1
{
    /// <summary>
    /// Finds out the value of operator
    /// And returns a number corrosponding
    /// </summary>
    class TokenCheck
    {
        public int FindOperator(ConstantExpression node)
        {
            if (node.Value.Equals("+"))
            {
                return 1;
            }
            else if (node.Value.Equals("-"))
            {
                return 2;
            }            
            else if (node.Value.Equals("*"))
            {
                return 3;
            }
            else if (node.Value.Equals("/"))
            {
                return 4;
            }
            else
            return 0;
        }

        /// <summary>
        /// This method has parameter "TypeOfFlag" in order to create the correct binary expression
        /// And the parameter "ExpressionStack" for popping off operands to create the expression
        /// And returns the expression to stack
        /// </summary>
        /// <param name="TypeOfFlag"></param>
        /// <param name="ExpressionStack"></param>
        /// <returns></returns>
        public BinaryExpression CreateBinaryExpression(int TypeOfFlag, Stack<Expression> ExpressionStack)
        {
            BinaryExpression Nothing = null;

            if (TypeOfFlag == 1)
            {
                Expression right = ExpressionStack.Pop();
                Expression left = ExpressionStack.Pop();
                return Expression.MakeBinary(ExpressionType.Add, left, right);
            }
            else if (TypeOfFlag == 2)
            {
                Expression right = ExpressionStack.Pop();
                Expression left = ExpressionStack.Pop();
                return Expression.MakeBinary(ExpressionType.Subtract, left, right);
            }
            else if (TypeOfFlag == 3)
            {
                Expression right = ExpressionStack.Pop();
                Expression left = ExpressionStack.Pop();
                return Expression.MakeBinary(ExpressionType.Multiply, left, right);
            }
            else if (TypeOfFlag == 4)
            {
                Expression right = ExpressionStack.Pop();
                Expression left = ExpressionStack.Pop();
                return Expression.MakeBinary(ExpressionType.Divide, left, right);
            }
            
            return Nothing;
        }
    }
}
