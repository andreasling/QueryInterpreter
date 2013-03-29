namespace QueryInterpreter
{
    public class AndExpression : BooleanExpression
    {
        private readonly BooleanExpression left;
        private readonly BooleanExpression right;

        public AndExpression(BooleanExpression left, BooleanExpression right)
        {
            this.left = left;
            this.right = right;
        }

        public virtual string Interpret()
        {
            return (Value).ToString().ToLower();
        }

        public bool Value
        {
            get { return left.Value && right.Value; }
        }
    }
}
