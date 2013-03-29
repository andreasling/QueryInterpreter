using QueryInterpreter.Expressions;

namespace QueryInterpreter.Parser
{
    public class QueryParser
    {
        private readonly string query;

        public QueryParser(string query)
        {
            this.query = query;
        }

        public Expression Parse()
        {
            return new BooleanLiteralExpression(bool.Parse(query));
        }
    }
}