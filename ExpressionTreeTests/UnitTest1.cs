
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment1;
using System.Linq.Expressions;

namespace ExpressionTreeTests
{
    [TestClass]
    public class ExpressionTests
    {
        [TestMethod]
        public void TestToPass()
        {
            //Arrange
            CalculateExpression calculateExpression = new CalculateExpression();
            BinaryExpression ExpressionTree = null;
            MyExpressionVisitor myExpressionVisitor = new MyExpressionVisitor();
            string TestToPassExpression = "15 7 1 1 + - / 3 * 2 1 1 + + -";

            //Act
            ExpressionTree = calculateExpression.CalculateValidExpression(TestToPassExpression, ExpressionTree, myExpressionVisitor);
            var results = Expression.Lambda(ExpressionTree).Compile().DynamicInvoke();
            //Assert
            Assert.AreEqual(5.00,results);
            
        }

        [TestMethod]
        [ExpectedException(typeof(System.InvalidOperationException))]
        public void TestToFail_TestToFail()
        {
            //Arrange
            CalculateExpression calculateExpression = new CalculateExpression();
            BinaryExpression ExpressionTree = null;
            MyExpressionVisitor myExpressionVisitor = new MyExpressionVisitor();
            string TestToPassExpression = "1 + 1";

            //Act
            ExpressionTree = calculateExpression.CalculateValidExpression(TestToPassExpression, ExpressionTree, myExpressionVisitor);
            var results = Expression.Lambda(ExpressionTree).Compile().DynamicInvoke();
            //Assert
            Assert.Fail();

        }

        [TestMethod]
        public void TestToFail_DivideByZero()
        {
            //Arrange
            CalculateExpression calculateExpression = new CalculateExpression();
            MyExpressionVisitor myExpressionVisitor = new MyExpressionVisitor();
            Validation validation = new Validation();

            string TestToFailExpression = "1 1 + 0 /";
            bool IsValidExpression = false;

            //Act
            bool results = validation.IsValid(TestToFailExpression, IsValidExpression);
            
            //Assert
            Assert.AreEqual(false, results);

        }

        [TestMethod]
        public void TestBoundaries()
        {
            //Arrange
            CalculateExpression calculateExpression = new CalculateExpression();
            BinaryExpression ExpressionTree = null;
            MyExpressionVisitor myExpressionVisitor = new MyExpressionVisitor();
            string TestToPassExpression = "999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999 1 +";

            //Act
            ExpressionTree = calculateExpression.CalculateValidExpression(TestToPassExpression, ExpressionTree, myExpressionVisitor);
            var results = Expression.Lambda(ExpressionTree).Compile().DynamicInvoke();
            //Assert
            Assert.AreEqual(1000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000.00, results);

        }
    }
}
