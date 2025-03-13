namespace MathInterpreter
{
    public class BinaryOperationNode : ASTNode
    {
        public ASTNode Left { get; }
        public Token Operator { get; }
        public ASTNode Right { get; }

        public BinaryOperationNode(ASTNode left, Token operatorToken, ASTNode right)
        {
            Left = left;
            Operator = operatorToken;
            Right = right;
        }
    }
}
