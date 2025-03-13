namespace MathInterpreter
{
    public class Parser
    {
        private readonly List<Token> _tokens;
        private int _position;

        public Parser(List<Token> tokens)
        {
            _tokens = tokens;
            _position = 0;
        }

        private Token Current => _position < _tokens.Count ? _tokens[_position] : null;

        private void Advance()
        {
            _position++;
        }

        private Token Expect(TokenType type)
        {
            if (Current.Type == type)
            {
                var token = Current;
                Advance();
                return token;
            }
            throw new Exception($"Expected {type} but got {Current.Type}");
        }

        public ASTNode Parse()
        {
            return ParseExpression();
        }

        // Grammar:
        // expression = term (("+" | "-") term)*
        private ASTNode ParseExpression()
        {
            var left = ParseTerm();

            while (Current.Type == TokenType.Plus || Current.Type == TokenType.Minus)
            {
                var operatorToken = Current;
                Advance();
                var right = ParseTerm();
                left = new BinaryOperationNode(left, operatorToken, right);
            }

            return left;
        }

        // term = factor (("*" | "/") factor)*
        private ASTNode ParseTerm()
        {
            var left = ParseFactor();

            while (Current.Type == TokenType.Multiply || Current.Type == TokenType.Divide)
            {
                var operatorToken = Current;
                Advance();
                var right = ParseFactor();
                left = new BinaryOperationNode(left, operatorToken, right);
            }

            return left;
        }

        // factor = NUMBER | "(" expression ")"
        private ASTNode ParseFactor()
        {
            if (Current.Type == TokenType.Number)
            {
                var value = double.Parse(Current.Value);
                Advance();
                return new NumberNode(value);
            }

            if (Current.Type == TokenType.LeftParen)
            {
                Advance();
                var expression = ParseExpression();
                Expect(TokenType.RightParen);
                return expression;
            }

            throw new Exception($"Unexpected token: {Current.Type}");
        }
    }
}
