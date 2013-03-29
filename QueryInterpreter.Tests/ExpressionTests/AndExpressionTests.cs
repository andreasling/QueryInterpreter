using NUnit.Framework;

namespace QueryInterpreter.Tests
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
                    new BinaryLiteralExpression(true), 
                    new BinaryLiteralExpression(true))
                    .Interpret());
        }

        [Test]
        public void ShouldEvaluateToFalse()
        {
            Assert.AreEqual(
                "false", 
                new AndExpression(
                    new BinaryLiteralExpression(true), 
                    new BinaryLiteralExpression(false))
                    .Interpret());
        }
    }
}
