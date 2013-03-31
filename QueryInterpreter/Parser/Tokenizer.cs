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

            var whitespaceExpression = new Regex(@"\s+", RegexOptions.Compiled | RegexOptions.ExplicitCapture);

            var operatorExpression = new Regex(@"\(|\)", RegexOptions.Compiled | RegexOptions.ExplicitCapture);

            var keywordExpression = new Regex(@"(true|false|not|and|or)(?=$|[\s\(\)])", RegexOptions.Compiled | RegexOptions.ExplicitCapture);

            var stringExpression = new Regex(@"""([^""\\]|\\""|\\\\|\\t)*""", RegexOptions.Compiled | RegexOptions.ExplicitCapture);

            while (i < expression.Length)
            {
                Match match;

                if (MatchesAtIndex(match = whitespaceExpression.Match(expression, i), i))
                {
                    // skip white spaces
                }
                else if (
                    MatchesAtIndex(match = operatorExpression.Match(expression, i), i) ||
                    MatchesAtIndex(match = keywordExpression.Match(expression, i), i) ||
                    MatchesAtIndex(match = stringExpression.Match(expression, i), i))
                {
                    yield return match.Value;
                }
                else
                    throw new ApplicationException("unexpected character " + expression[i]);

                i += match.Length;
            }
        }

        private static bool MatchesAtIndex(Match match, int i)
        {
            return match.Index == i && match.Success;
        }
    }
}