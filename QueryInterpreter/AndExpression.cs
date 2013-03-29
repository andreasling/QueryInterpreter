namespace QueryInterpreter
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
    }
}
