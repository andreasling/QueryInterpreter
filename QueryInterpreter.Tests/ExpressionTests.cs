using NUnit.Framework;

namespace QueryInterpreter.Tests
{
    [TestFixture]
    public class ExpressionTests
    {
        [Test]
        public void ShouldEvaluateStringLiteralExpression()
        {
            Assert.AreEqual(
                "value", 
                new StringLiteralExpression("value")
                .Interpret());
        }

        [Test]
        public void ShouldEvaluateEqualsExpression()
        {
            Assert.AreEqual(
                "false", 
                new EqualsExpression(
                    new StringLiteralExpression("left"), 
                    new StringLiteralExpression("right"))
                    .Interpret());
        }

        [Test]
        public void ShouldEvaluateBinaryLiteralExpressionToTrue()
        {
            Assert.AreEqual(
                "true", 
                new BinaryLiteralExpression(true)
                .Interpret());
        }

        [Test]
        public void ShouldEvaluateBinaryLiteralExpressionToFalse()
        {
            Assert.AreEqual(
                "false", 
                new BinaryLiteralExpression(false)
                .Interpret());
        }

        [Test]
        public void ShouldEvaluateAndExpressionToTrue()
        {
            Assert.AreEqual(
                "true", 
                new AndExpression(
                    new BinaryLiteralExpression(true), 
                    new BinaryLiteralExpression(true))
                    .Interpret());
        }

        [Test]
        public void ShouldEvaluateAndExpressionToFalse()
        {
            Assert.AreEqual(
                "false", 
                new AndExpression(
                    new BinaryLiteralExpression(true), 
                    new BinaryLiteralExpression(false))
                    .Interpret());
        }

        [Test]
        public void ShouldEvaluateOrExpressionToTrue()
        {
            Assert.AreEqual(
                "true", 
                new OrExpression(
                    new BinaryLiteralExpression(true), 
                    new BinaryLiteralExpression(false))
                    .Interpret());
        }

        [Test]
        public void ShouldEvaluateOrExpressionToFalse()
        {
            Assert.AreEqual(
                "false", 
                new OrExpression(
                    new BinaryLiteralExpression(false), 
                    new BinaryLiteralExpression(false))
                    .Interpret());
        }

        [Test]
        public void ShouldEvaluateNotExpressionToFalse()
        {
            Assert.AreEqual(
                "false", 
                new NotExpression(
                    new BinaryLiteralExpression(true))
                    .Interpret());
        }
    }
}
