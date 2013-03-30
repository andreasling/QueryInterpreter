namespace QueryInterpreter.Expressions
{
    public class AndExpression : BooleanBinaryOperatorExpression
    {
        public AndExpression(BooleanExpression left, BooleanExpression right)
            : base(left, right)
        {
        }

        protected internal override bool Value
        {
            get { return Left.Value && Right.Value; }
        }

        public override bool Equals(object obj)
        {
            if (obj is AndExpression)
            {
                var other = obj as AndExpression;

                return
                    Left.Equals(other.Left) &&
                    Right.Equals(other.Right);
            }

            return false;
        }
    }
}
