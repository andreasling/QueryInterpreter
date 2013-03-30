using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace QueryInterpreter.Parser
{
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

            var whitespaceExpression = new Regex(@"\s+", RegexOptions.Compiled);

            var tokenExpression = new Regex(@"(\(|\)|((true|not)(?=$|[\s\)])))", RegexOptions.Compiled | RegexOptions.ExplicitCapture);

            while (i < expression.Length)
            {
                Match match;

                if ((match = whitespaceExpression.Match(expression, i)).Index == i && match.Success)
                {
                    i += match.Length;
                }
                else if ((match = tokenExpression.Match(expression, i)).Index == i && match.Success)
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