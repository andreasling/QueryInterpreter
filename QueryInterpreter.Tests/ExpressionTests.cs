using NUnit.Framework;

namespace QueryInterpreter.Tests
{
    [TestFixture]
    public class ExpressionTests
    {
        [Test]
        public void ShouldEvaluateStringLiteralExpression()
        {
            var expected = "value";

            Expression expression = new StringLiteralExpression(expected);

            var actual = expression.Interpret();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ShouldEvaluateEqualsExpression()
        {
            Expression left = new StringLiteralExpression("left");
            Expression right = new StringLiteralExpression("right");

            Expression expression = new EqualsExpression(left, right);

            var actual = expression.Interpret();

            Assert.AreEqual("false", actual);
        }

        [Test]
        public void ShouldEvaluateBinaryLiteralExpressionToTrue()
        {
            var expression = new BinaryLiteralExpression(true);

            Assert.AreEqual("true", expression.Interpret());
        }

        [Test]
        public void ShouldEvaluateBinaryLiteralExpressionToFalse()
        {
            var expression = new BinaryLiteralExpression(false);

            Assert.AreEqual("false", expression.Interpret());
        }

        [Test]
        public void ShouldEvaluateAndExpressionToTrue()
        {
            BooleanExpression left = new BinaryLiteralExpression(true);
            BooleanExpression right = new BinaryLiteralExpression(true);

            var expression = new AndExpression(left, right);

            var actual = expression.Interpret();

            Assert.AreEqual("true", actual);
        }

        [Test]
        public void ShouldEvaluateAndExpressionToFalse()
        {
            BooleanExpression left = new BinaryLiteralExpression(true);
            BooleanExpression right = new BinaryLiteralExpression(false);

            var expression = new AndExpression(left, right);

            var actual = expression.Interpret();

            Assert.AreEqual("false", actual);
        }

        [Test]
        public void ShouldEvaluateOrExpressionToTrue()
        {
            BooleanExpression left = new BinaryLiteralExpression(true);
            BooleanExpression right = new BinaryLiteralExpression(false);

            var expression = new OrExpression(left, right);

            var actual = expression.Interpret();

            Assert.AreEqual("true", actual);
        }

        [Test]
        public void ShouldEvaluateOrExpressionToFalse()
        {
            BooleanExpression left = new BinaryLiteralExpression(false);
            BooleanExpression right = new BinaryLiteralExpression(false);

            var expression = new OrExpression(left, right);

            var actual = expression.Interpret();

            Assert.AreEqual("false", actual);
        }

        [Test]
        public void ShouldEvaluateNotExpressionToFalse()
        {
            BooleanExpression value = new BinaryLiteralExpression(true);

            var expression = new NotExpression(value);

            var actual = expression.Interpret();

            Assert.AreEqual("false", actual);
        }
    }
}