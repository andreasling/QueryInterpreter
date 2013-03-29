namespace QueryInterpreter.Expressions
{
    public class BooleanLiteralExpression : BooleanExpression
    {
        private readonly bool value;

        public BooleanLiteralExpression(bool value)
        {
            this.value = value;
        }

        public override string Interpret()
        {
            return Value.ToString().ToLower();
        }

        protected internal override bool Value
        {
            get { return value; }
        }

        public override bool Equals(object obj)
        {
            if (obj is BooleanLiteralExpression)
            {
                var other = obj as BooleanLiteralExpression;

                return bool.Equals(value, other.value);
            }

            return false;
        }
    }
}
