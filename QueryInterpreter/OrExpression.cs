namespace QueryInterpreter
{
    public class OrExpression : BooleanBinaryOperatorExpression
    {
        public OrExpression(BooleanExpression left, BooleanExpression right)
            : base(left, right)
        {
        }

        protected internal override bool Value
        {
            get { return Left.Value || Right.Value; }
        }
    }
}
