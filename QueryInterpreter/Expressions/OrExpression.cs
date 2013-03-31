namespace QueryInterpreter.Expressions
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

        public override bool Equals(object obj)
        {
            if (obj is OrExpression)
            {
                var other = obj as OrExpression;

                return
                    Left.Equals(other.Left) &&
                    Right.Equals(other.Right);
            }

            return false;
        }
    }
}
