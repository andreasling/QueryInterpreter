﻿using NUnit.Framework;
using QueryInterpreter.Expressions;

namespace QueryInterpreter.Tests.ExpressionTests
{
    [TestFixture]
    public class EqualsExpressionTests
    {
        [Test]
        public void ShouldEvaluateToTrue()
        {
            Assert.AreEqual(
                "true",
                new EqualsExpression(
                    new StringLiteralExpression("same"),
                    new StringLiteralExpression("same"))
                    .Interpret());
        }

        [Test]
        public void ShouldEvaluateToFalse()
        {
            Assert.AreEqual(
                "false",
                new EqualsExpression(
                    new StringLiteralExpression("left"),
                    new StringLiteralExpression("right"))
                    .Interpret());
        }
    }
}
