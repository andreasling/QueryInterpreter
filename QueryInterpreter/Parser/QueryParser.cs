using System.Text.RegularExpressions;
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
            return ParseExpression(query);
        }

        private static Expression ParseExpression(string expression)
        {
            if (expression.StartsWith("("))
                return ParseExpression(expression.Trim('(').Trim(')'));

            if (expression.StartsWith("\"")) 
                return new StringLiteralExpression(expression.Trim('"'));

            if (expression.StartsWith("not "))
            {
                var subExpression = (BooleanExpression)ParseExpression(Regex.Replace(expression, @"^not\s+", string.Empty));
                return new NotExpression(subExpression);
            }
            
            return new BooleanLiteralExpression(bool.Parse(expression));
        }
    }
}