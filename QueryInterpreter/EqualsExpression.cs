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

        public virtual string Interpret()
        {
            return Value.ToString().ToLower();
        }

        public bool Value
        {
            get { return string.Equals(left, right); }
        }
    }
}
