namespace QueryInterpreter
{
    public class OrExpression : BooleanExpression
    {
        private readonly BooleanExpression left;
        private readonly BooleanExpression right;

        public OrExpression(BooleanExpression left, BooleanExpression right)
        {
            this.left = left;
            this.right = right;
        }

        public string Interpret()
        {
            return Value.ToString().ToLower();
        }

        public bool Value
        {
            get { return left.Value || right.Value; }
        }
    }
}
