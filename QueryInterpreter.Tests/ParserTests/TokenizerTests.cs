using System.Linq;
using NUnit.Framework;
using QueryInterpreter.Parser;

namespace QueryInterpreter.Tests.ParserTests
{
    [TestFixture]
    public class TokenizerTests
    {
        [Test]
        public void ShouldTokenizeEmptyExpression()
        {
            CollectionAssert.AreEqual(
                Enumerable.Empty<string>(),
                new Tokenizer("").Tokenize());
        }

        [Test]
        public void ShouldTokenizeSingleLiteralExpression()
        {
            CollectionAssert.AreEqual(
                new[] { "true" },
                new Tokenizer("true").Tokenize());
        }

        [Test]
        public void ShouldTokenizeSpaceSeparatedTokens()
        {
            CollectionAssert.AreEqual(
                new[] {"not", "true"},
                new Tokenizer("not true").Tokenize());
        }

        [Test]
        public void ShouldTokenizeParenthesisExpression()
        {
            CollectionAssert.AreEqual(
                new[] { "(", "true", ")" },
                new Tokenizer("(true)").Tokenize());
        }

        [Test]
        public void ShouldTokenizeParenthesisExpressionWithSpaces()
        {
            CollectionAssert.AreEqual(
                new[] { "(", "true", ")" },
                new Tokenizer(" ( true ) ").Tokenize());
        }

        [Test]
        public void ShouldTokenizeNestedParenthesisExpression()
        {
            CollectionAssert.AreEqual(
                new[] { "(", "(", "true", "and", "false", ")", "or", "(", "not", "false", ")" },
                new Tokenizer("((true and false)or ( not false ) ").Tokenize());
        }

        [Test]
        public void ShouldTokenizeKeywords()
        {
            CollectionAssert.AreEqual(
                new[] { "true", "and", "not", "true", "or", "false" },
                new Tokenizer("true and not true or false").Tokenize());
        }
    }
}
