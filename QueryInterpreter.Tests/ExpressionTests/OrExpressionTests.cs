﻿using NUnit.Framework;

namespace QueryInterpreter.Tests
{
    [TestFixture]
    public class OrExpressionTests
    {
        [Test]
        public void ShouldEvaluateToTrue()
        {
            Assert.AreEqual(
                "true", 
                new OrExpression(
                    new BinaryLiteralExpression(true), 
                    new BinaryLiteralExpression(false))
                    .Interpret());
        }

        [Test]
        public void ShouldEvaluateToFalse()
        {
            Assert.AreEqual(
                "false", 
                new OrExpression(
                    new BinaryLiteralExpression(false), 
                    new BinaryLiteralExpression(false))
                    .Interpret());
        }
    }
}