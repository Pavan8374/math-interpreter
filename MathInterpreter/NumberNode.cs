namespace MathInterpreter
{
    public class NumberNode : ASTNode
    {
        public double Value { get; }

        public NumberNode(double value)
        {
            Value = value;
        }
    }
}
