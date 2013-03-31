namespace QueryInterpreter.Expressions
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
            get { return string.Equals(left.Interpret(), right.Interpret()); }
        }

        public override bool Equals(object obj)
        {
            if (obj is EqualsExpression)
            {
                var other = obj as EqualsExpression;

                return
                    left.Equals(other.left) &&
                    right.Equals(other.right);
            }

            return false;
        }
    }
}
