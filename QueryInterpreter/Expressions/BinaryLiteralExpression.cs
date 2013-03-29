namespace QueryInterpreter.Expressions
{
    public class BinaryLiteralExpression : BooleanExpression
    {
        private readonly bool value;

        public BinaryLiteralExpression(bool value)
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
            if (obj is BinaryLiteralExpression)
            {
                var other = obj as BinaryLiteralExpression;

                return bool.Equals(value, other.value);
            }

            return false;
        }
    }
}
