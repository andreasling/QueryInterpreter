using NUnit.Framework;
using QueryInterpreter.Expressions;
using QueryInterpreter.Parser;

namespace QueryInterpreter.Tests.ParserTests
{
    [TestFixture]
    public class ParserTests
    {
        [Test]
        public void ShouldParseBooleanTrueLiteral()
        {
            Assert.AreEqual(
                new BooleanLiteralExpression(true),
                new QueryParser("true").Parse()
                );
        }

        [Test]
        public void ShouldParseStringLiteral()
        {
            Assert.AreEqual(
                new StringLiteralExpression("string"),
                new QueryParser("\"string\"").Parse());
        }

        [Test]
        public void ShouldParseParenthisesExpression()
        {
            Assert.AreEqual(
                new BooleanLiteralExpression(true),
                new QueryParser("(true)").Parse()
                );
        }

        [Test]
        public void ShouldParseNotExpression()
        {
            Assert.AreEqual(
                new NotExpression(new BooleanLiteralExpression(true)),
                new QueryParser("not true").Parse());
        }

        [Test]
        public void ShouldParseNestedParathesiziedNotExpressions()
        {
            Assert.AreEqual(
                new NotExpression(new NotExpression(new BooleanLiteralExpression(true))),
                new QueryParser("(not (not true))").Parse());
        }

        [Test]
        public void ShouldParseAndExpression()
        {
            Assert.AreEqual(
                new AndExpression(new BooleanLiteralExpression(true), new BooleanLiteralExpression(true)),
                new QueryParser("true and true").Parse());
        }

        [Test]
        public void ShouldParseOrExpression()
        {
            Assert.AreEqual(
                new OrExpression(new BooleanLiteralExpression(true), new BooleanLiteralExpression(false)),
                new QueryParser("true or false").Parse());
        }

        [Test]
        public void ShouldParseEqualsExpression()
        {
            Assert.AreEqual(
                new EqualsExpression(new BooleanLiteralExpression(true), new BooleanLiteralExpression(true)),
                new QueryParser("true=true").Parse());
        }

        [Test]
        public void ShouldParseComplexExpression()
        {
            var actual = new QueryParser("not true=(not \"\"= \"hello\" or false or true) and \"a = b\" =\"a = b\"").Parse();
            var expected = 
                new NotExpression(
                    new EqualsExpression(
                        new BooleanLiteralExpression(true), 
                        new OrExpression(
                            new NotExpression(
                                new EqualsExpression(
                                    new StringLiteralExpression("hello"), 
                                    new StringLiteralExpression("hello"))),

        }
    }
}

