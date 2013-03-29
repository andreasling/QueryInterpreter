namespace QueryInterpreter
{
    public class EqualsExpression : BooleanExpression
    {
        private readonly Expression left;
        private readonly Expression right;

        public EqualsExpression(Expression left, Expression right)
        {
            this.left = left;
            this.right = right;
        }

        public override string Interpret()
        {
            return Value.ToString().ToLower();
        }

        protected internal override bool Value
        {
            get { return string.Equals(left, right); }
        }
    }
}
