using NUnit.Framework;
using QueryInterpreter.Expressions;

namespace QueryInterpreter.Tests.ExpressionTests
{
    [TestFixture]
    public class BinaryLiteralExpressionTests
    {
        [Test]
        public void ShouldEvaluateToTrue()
        {
            Assert.AreEqual(
                "true", 
                new BooleanLiteralExpression(true)
                    .Interpret());
        }

        [Test]
        public void ShouldEvaluateToFalse()
        {
            Assert.AreEqual(
                "false", 
                new BooleanLiteralExpression(false)
                    .Interpret());
        }

        [Test]
        public void ShouldImplementEquals()
        {
            Assert.AreEqual(
                new BooleanLiteralExpression(false), 
                new BooleanLiteralExpression(false));
        }
    }
}
