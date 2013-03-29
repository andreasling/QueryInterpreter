namespace QueryInterpreter
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
    }
}
