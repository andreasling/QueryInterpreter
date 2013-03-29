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
                new BinaryLiteralExpression(true)
                    .Interpret());
        }

        [Test]
        public void ShouldEvaluateToFalse()
        {
            Assert.AreEqual(
                "false", 
                new BinaryLiteralExpression(false)
                    .Interpret());
        }

        [Test]
        public void ShouldImplementEquals()
        {
            Assert.AreEqual(
                new BinaryLiteralExpression(false), 
                new BinaryLiteralExpression(false));
        }
    }
}
