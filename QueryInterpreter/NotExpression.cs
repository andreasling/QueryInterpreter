namespace QueryInterpreter
{
    public class NotExpression : BooleanExpression
    {
        private readonly BooleanExpression expression;

        public NotExpression(BooleanExpression expression)
        {
            this.expression = expression;
        }

        public string Interpret()
        {
            return Value.ToString().ToLower();
        }

        public bool Value
        {
            get { return !expression.Value; }
        }
    }
}
