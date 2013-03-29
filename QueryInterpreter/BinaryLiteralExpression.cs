namespace QueryInterpreter
{
    public class BinaryLiteralExpression : BooleanExpression
    {
        public BinaryLiteralExpression(bool value)
        {
            Value = value;
        }

        public virtual string Interpret()
        {
            return Value.ToString().ToLower();
        }

        public bool Value { get; private set; }
    }
}

