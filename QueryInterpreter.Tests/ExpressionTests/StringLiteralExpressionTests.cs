using NUnit.Framework;
using QueryInterpreter.Expressions;

namespace QueryInterpreter.Tests.ExpressionTests
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
