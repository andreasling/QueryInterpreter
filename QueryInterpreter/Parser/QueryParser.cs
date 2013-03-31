using System;
using System.Collections.Generic;
using System.Linq;
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
            var tokens = new Tokenizer(query).Tokenize();

            return ParseExpression(new Queue<string>(tokens));
        }

        private static Expression ParseExpression(Queue<string> tokens)
        {
            Expression expression = null;

            var token = tokens.Dequeue();

            if (token.StartsWith("\""))
            {
                expression = new StringLiteralExpression(Regex.Unescape(token.Trim('"')));
            }
            else if (token == "(")
            {
                expression = ParseExpression(tokens);

                var endToken = tokens.Dequeue();
                if (endToken != ")")
                    throw new ApplicationException("unexpected token " + endToken);
            }
            else if (token == "true" || token == "false")
            {
                expression = new BooleanLiteralExpression(bool.Parse(token));
            }
            else if (token == "not")
            {
                expression = new NotExpression(ParseExpression(tokens) as BooleanExpression);
            }

            if (tokens.Any() && tokens.Peek() == "and")
            {
                tokens.Dequeue();
                expression = new AndExpression(expression as BooleanExpression, ParseExpression(tokens) as BooleanExpression);
            }
            else if (tokens.Any() && tokens.Peek() == "or")
            {
                tokens.Dequeue();
                expression = new OrExpression(expression as BooleanExpression, ParseExpression(tokens) as BooleanExpression);
            }


            return expression;
        }
    }
}