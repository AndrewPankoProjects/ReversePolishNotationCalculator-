/*
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
    public class MyExpressionVisitor : ExpressionVisitor
    {
        Stack<Expression> visitStack = new Stack<Expression>();
        TokenCheck GoToCheckOperator = new TokenCheck();
        private BinaryExpression root;
        
        /// <summary>
        /// This method passes in a parameter of type expression called "node"
        /// The switch statement identifies the NodeType of "node" 
        /// And goes to the VisitConstant class if the NodeType is constant
        /// Otherwise returns base of node
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public override Expression Visit(Expression node)
        {
            switch (node.NodeType)
            {
                //Checks for Nodetype of node as constant
                case ExpressionType.Constant:
                    return this.VisitConstant((ConstantExpression)node);
                default:
                    return base.Visit(node);
            }
        }

        /// <summary>
        /// This method takes in a parameter of type BinaryExpression (i.e. (1+1)) called "node"
        /// And stores the node in a variable called "root", and pushes it onto the stack
        /// And returns root variable 
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        protected override Expression VisitBinary(BinaryExpression node)
        {
            this.root = node;
            this.visitStack.Push(this.root);
            return this.root;
        }
        
        /// <summary>
        /// This method takes in a parameter of type ConstantExpression called "node"
        /// And then checks if the value of node is an operator or operand
        /// Then either pushes the operand onto the stack immediately OR 
        /// Sends the operator to the VisitBinary Class
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        protected override Expression VisitConstant(ConstantExpression node)
        {
            //Returns the type of operator
            int TypeOfOperator = GoToCheckOperator.FindOperator(node);
            //Goes to VisitBinary Class if operator
            if (TypeOfOperator != 0)
            {
                BinaryExpression ExpressionToPushOnStack = GoToCheckOperator.CreateBinaryExpression(TypeOfOperator, visitStack);
                return VisitBinary(ExpressionToPushOnStack);
            }
            //Pushes on stack if operand
            else
            {
                this.visitStack.Push(node);
                return this.root;
            }
        }
    }
}
