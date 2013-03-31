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

        [Test]
        public void ShouldTokenizeEmptyString()
        {
            CollectionAssert.AreEqual(
                new [] { "\"\"" },
                new Tokenizer("\"\"").Tokenize());
        }

        [Test]
        public void ShouldTokenizeString()
        {
            CollectionAssert.AreEqual(
                new[] { "\"string\"" },
                new Tokenizer("\"string\"").Tokenize());
        }

        [Test]
        public void ShouldTokenizeStringWithQuote()
        {
            CollectionAssert.AreEqual(
                new[] { "\"str\\\"ing\"" },
                new Tokenizer("\"str\\\"ing\"").Tokenize());
        }

        [Test]
        public void ShouldTokenizeStringWithEscapedEscape()
        {
            CollectionAssert.AreEqual(
                new[] { @"""str\\ing""" },
                new Tokenizer(@"""str\\ing""").Tokenize());
        }

        [Test]
        public void ShouldTokenizeStringWithEscapedEscapeNearEnd()
        {
            CollectionAssert.AreEqual(
                new[] { @"""string\\""" },
                new Tokenizer(@"""string\\""").Tokenize());
        }

        [Test]
        public void ShouldTokenizeStringWithEscapedTab()
        {
            CollectionAssert.AreEqual(
                new[] { @"""string\tstrong""" },
                new Tokenizer(@"""string\tstrong""").Tokenize());
        }

        [Test]
        public void ShouldTokenizeEqualsExpression()
        {
            CollectionAssert.AreEqual(
                new[]{"true","=","true"},
                new Tokenizer("true=true").Tokenize());
        }
    }
}
