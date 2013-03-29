namespace QueryInterpreter.Expressions
{
    public abstract class BooleanExpression : Expression
    {
        protected internal abstract bool Value { get; }
        public abstract string Interpret();
    }
}
