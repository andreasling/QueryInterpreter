using NUnit.Framework;

namespace QueryInterpreter.Tests
{
    [TestFixture]
    public class StringLiteralExpressionTests
    {
        [Test]
        public void ShouldEvaluateToValue()
        {
            Assert.AreEqual(
                "value", 
                new StringLiteralExpression("value")
                .Interpret());
        }
    }
}
