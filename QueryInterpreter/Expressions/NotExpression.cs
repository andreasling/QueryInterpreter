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

        public override bool Equals(object obj)
        {
            if (obj is NotExpression)
            {
                var other = obj as NotExpression;

                return expression.Equals(other.expression);
            }

            return false;
        }
    }
}
