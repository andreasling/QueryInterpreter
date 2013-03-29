namespace QueryInterpreter.Expressions
{
    public class StringLiteralExpression : Expression
    {
        private readonly string value;

        public StringLiteralExpression(string value)
        {
            this.value = value;
        }

        public virtual string Interpret()
        {
            return value;
        }
    }
}
