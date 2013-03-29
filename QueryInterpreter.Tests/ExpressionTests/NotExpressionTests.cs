﻿using NUnit.Framework;
using QueryInterpreter.Expressions;

namespace QueryInterpreter.Tests.ExpressionTests
{
    [TestFixture]
    public class NotExpressionTests
    {
        [Test]
        public void ShouldEvaluateToTrue()
        {
            Assert.AreEqual(
                "true",
                new NotExpression(
                    new BooleanLiteralExpression(false))
                    .Interpret());
        }

        [Test]
        public void ShouldEvaluateToFalse()
        {
            Assert.AreEqual(
                "false",
                new NotExpression(
                    new BooleanLiteralExpression(true))
                    .Interpret());
        }
    }
}
