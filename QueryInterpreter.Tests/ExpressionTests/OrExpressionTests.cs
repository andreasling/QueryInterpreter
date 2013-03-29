using NUnit.Framework;
using QueryInterpreter.Expressions;

namespace QueryInterpreter.Tests.ExpressionTests
{
    [TestFixture]
    public class OrExpressionTests
    {
        [Test]
        public void ShouldEvaluateToTrue()
        {
            Assert.AreEqual(
                "true", 
                new OrExpression(
                    new BooleanLiteralExpression(true), 
                    new BooleanLiteralExpression(false))
                    .Interpret());
        }

        [Test]
        public void ShouldEvaluateToFalse()
        {
            Assert.AreEqual(
                "false", 
                new OrExpression(
                    new BooleanLiteralExpression(false), 
                    new BooleanLiteralExpression(false))
                    .Interpret());
        }
    }
}
