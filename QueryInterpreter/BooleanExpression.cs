namespace QueryInterpreter
{
    public interface BooleanExpression : Expression
    {
        bool Value { get; }
    }
}
