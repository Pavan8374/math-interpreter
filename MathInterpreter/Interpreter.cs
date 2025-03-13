using System.Linq.Expressions;

namespace MathInterpreter
{
    public class Interpreter
    {
        private readonly ASTNode _root;

        public Interpreter(ASTNode root)
        {
            _root = root;
        }

        public double Interpret()
        {
            return Evaluate(_root);
        }

        private double Evaluate(ASTNode node)
        {
            if (node is NumberNode number)
            {
                return number.Value;
            }
            if (node is BinaryOperationNode binaryOp)
            {
                return EvaluateBinaryOperationNode(binaryOp);
            }
            throw new Exception("Unknown node type");
        }
        private int EvaluateBinaryOperationNode(BinaryOperationNode node)
        {
            int left = (int)Evaluate(node.Left);
            int right = (int)Evaluate(node.Right);

            switch (node.Operator.Type)
            {
                case TokenType.Plus:
                    return Add(left, right); // Already implemented bitwise addition

                case TokenType.Minus:
                    return Subtract(left, right);

                case TokenType.Multiply:
                    return Multiply(left, right);

                case TokenType.Divide:
                    return Divide(left, right);

                default:
                    throw new Exception($"Unknown operator: {node.Operator.Type}");
            }
        }
        private int Add(int a, int b)
        {
            while (b != 0)
            {
                int carry = a & b;
                a = a ^ b;
                b = carry << 1;
            }
            return a;
        }
        private int Subtract(int a, int b)
        {
            return Add(a, Add(~b, 1)); // a + (-b) = a - b
        }
        private int Multiply(int a, int b)
        {
            int result = 0;
            bool isNegative = false;

            if (b < 0)
            {
                b = Add(~b, 1); // Convert to positive
                isNegative = true;
            }

            while (b != 0)
            {
                if ((b & 1) != 0)
                {
                    result = Add(result, a);
                }
                a <<= 1; // Left shift (multiply by 2)
                b >>= 1; // Right shift (divide by 2)
            }

            return isNegative ? Add(~result, 1) : result; // Convert back to negative if needed
        }
        private int Divide(int a, int b)
        {
            if (b == 0) throw new DivideByZeroException();

            bool isNegative = (a < 0) ^ (b < 0); // XOR to check for opposite signs
            a = Math.Abs(a);
            b = Math.Abs(b);

            int result = 0;

            for (int i = 31; i >= 0; i = Subtract(i, 1))
            {
                if ((a >> i) >= b)
                {
                    a = Subtract(a, b << i);
                    result = Add(result, 1 << i);
                }
            }

            return isNegative ? Add(~result, 1) : result; // Convert back to negative if needed
        }
    }

}
