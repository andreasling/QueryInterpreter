﻿using NUnit.Framework;

namespace QueryInterpreter.Tests
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
                    new BinaryLiteralExpression(false))
                    .Interpret());
        }

        [Test]
        public void ShouldEvaluateToFalse()
        {
            Assert.AreEqual(
                "false",
                new NotExpression(
                    new BinaryLiteralExpression(true))
                    .Interpret());
        }
    }
}