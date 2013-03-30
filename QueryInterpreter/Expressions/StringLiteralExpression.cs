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

        public override bool Equals(object obj)
        {
            if (obj is StringLiteralExpression)
            {
                var other = obj as StringLiteralExpression;

                return string.Equals(value, other.value);
            }

            return false;
        }
    }
}
