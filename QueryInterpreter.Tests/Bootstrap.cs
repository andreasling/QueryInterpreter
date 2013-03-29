using NUnit.Framework;

namespace QueryInterpreter.Tests
{
    [TestFixture]
    public class Bootstrap
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
    }

    public class OrExpression : BooleanExpression
    {
        private readonly BooleanExpression left;
        private readonly BooleanExpression right;

        public OrExpression(BooleanExpression left, BooleanExpression right)
        {
            this.left = left;
            this.right = right;
        }

        public string Interpret()
        {
            return Value.ToString().ToLower();
        }

        public bool Value {
            get { return left.Value || right.Value; }
        }
    }

    public class AndExpression : BooleanExpression
    {
        private readonly BooleanExpression left;
        private readonly BooleanExpression right;

        public AndExpression(BooleanExpression left, BooleanExpression right)
        {
            this.left = left;
            this.right = right;
        }

        public virtual string Interpret()
        {
            return (Value).ToString().ToLower();
        }

        public bool Value
        {
            get { return left.Value && right.Value; }
        }
    }

    public interface BooleanExpression : Expression
    {
        bool Value { get; }
    }

    public class BinaryLiteralExpression : BooleanExpression
    {
        public BinaryLiteralExpression(bool value)
        {
            Value = value;
        }

        public virtual string Interpret()
        {
            return Value.ToString().ToLower();
        }

        public bool Value { get; private set; }
    }

    public class EqualsExpression : BooleanExpression
    {
        private readonly Expression left;
        private readonly Expression right;

        public EqualsExpression(Expression left, Expression right)
        {
            this.left = left;
            this.right = right;
        }

        public virtual string Interpret()
        {
            return Value.ToString().ToLower();
        }

        public bool Value
        {
            get { return string.Equals(left, right); }
        }
    }

    public interface Expression
    {
        string Interpret();
    }

    public class StringLiteralExpression : Expression
    {
        private string value;

        public StringLiteralExpression(string value)
        {
            this.value = value;
        }

        public virtual string Interpret()
        {
            return value;
        }
    }
}