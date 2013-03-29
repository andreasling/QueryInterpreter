namespace QueryInterpreter.Expressions
{
    public abstract class BooleanBinaryOperatorExpression : BooleanExpression
    {
        protected BooleanExpression Left;
        protected BooleanExpression Right;

        protected BooleanBinaryOperatorExpression(BooleanExpression left, BooleanExpression right)
        {
            Left = left;
            Right = right;
        }

        public override string Interpret()
        {
            return Value.ToString().ToLower();
        }
    }
}
