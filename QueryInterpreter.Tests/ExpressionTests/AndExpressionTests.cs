using NUnit.Framework;
using QueryInterpreter.Expressions;

namespace QueryInterpreter.Tests.ExpressionTests
{
    [TestFixture]
    public class AndExpressionTests
    {
        [Test]
        public void ShouldEvaluateToTrue()
        {
            Assert.AreEqual(
                "true", 
                new AndExpression(
                    new BooleanLiteralExpression(true), 
                    new BooleanLiteralExpression(true))
                    .Interpret());
        }

        [Test]
        public void ShouldEvaluateToFalse()
        {
            Assert.AreEqual(
                "false", 
                new AndExpression(
                    new BooleanLiteralExpression(true), 
                    new BooleanLiteralExpression(false))
                    .Interpret());
        }

        [Test]
        public void ShouldImplementEquals()
        {
            Assert.AreEqual(
                new AndExpression(new BooleanLiteralExpression(true), new BooleanLiteralExpression(true)),
                new AndExpression(new BooleanLiteralExpression(true), new BooleanLiteralExpression(true)));
        }
    }
}
