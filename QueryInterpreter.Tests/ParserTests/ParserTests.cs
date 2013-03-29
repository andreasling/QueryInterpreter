using NUnit.Framework;
using QueryInterpreter.Expressions;
using QueryInterpreter.Parser;

namespace QueryInterpreter.Tests.ParserTests
{
    [TestFixture]
    public class ParserTests
    {
        [Test]
        public void ShouldParseTrueLiteral()
        {
            Assert.AreEqual(
                new BinaryLiteralExpression(true),
                new QueryParser("true").Parse()
                );
        }
    }
}
