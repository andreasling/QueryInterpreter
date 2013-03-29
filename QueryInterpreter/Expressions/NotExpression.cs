namespace QueryInterpreter.Expressions
{
    public class NotExpression : BooleanExpression
    {
        private readonly BooleanExpression expression;

        public NotExpression(BooleanExpression expression)
        {
            this.expression = expression;
        }

        public override string Interpret()
        {
            return Value.ToString().ToLower();
        }

        protected internal override bool Value
        {
            get { return !expression.Value; }
        }
    }
}
