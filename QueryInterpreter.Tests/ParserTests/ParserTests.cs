using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
    }

    

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
                new[] { "(", "true", ")"},
                new Tokenizer("(true)").Tokenize());
        }
    }

    public class Tokenizer
    {
        private readonly string expression;

        public Tokenizer(string expression)
        {
            this.expression = expression;
        }
        
        public IEnumerable<string> Tokenize()
        {
            var tokens = Tokenize(expression).ToArray();
            return tokens;
        }

        private static IEnumerable<string> Tokenize(string expression)
        {
            var i = 0;

            var tokenExpression = new Regex(@"\s*?(\(|\)|((true|not)(?=$|[\s\)])))", RegexOptions.Compiled | RegexOptions.ExplicitCapture);

            while (i < expression.Length)
            {
                var match = tokenExpression.Match(expression, i);

                if (match.Success && match.Index == i)
                {
                    var t = match.Value;
                    i += t.Length;
                    yield return t.TrimStart();
                }
                else
                    throw new ApplicationException("unexpected character " + expression[i]);
            }
        }
    }
}
