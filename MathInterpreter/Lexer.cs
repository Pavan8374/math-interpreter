using System.Text;

namespace MathInterpreter
{
    public class Lexer
    {
        private readonly string _input;
        private int _position;

        public Lexer(string input)
        {
            _input = input;
            _position = 0;
        }

        public List<Token> Tokenize()
        {
            var tokens = new List<Token>();

            while (_position < _input.Length)
            {
                char current = _input[_position];

                if (char.IsWhiteSpace(current))
                {
                    _position++;
                    continue;
                }

                if (char.IsDigit(current))
                {
                    tokens.Add(ReadNumber());
                    continue;
                }

                switch (current)
                {
                    case '+':
                        tokens.Add(new Token(TokenType.Plus, current.ToString()));
                        break;
                    case '-':
                        tokens.Add(new Token(TokenType.Minus, current.ToString()));
                        break;
                    case '*':
                        tokens.Add(new Token(TokenType.Multiply, current.ToString()));
                        break;
                    case '/':
                        tokens.Add(new Token(TokenType.Divide, current.ToString()));
                        break;
                    case '(':
                        tokens.Add(new Token(TokenType.LeftParen, current.ToString()));
                        break;
                    case ')':
                        tokens.Add(new Token(TokenType.RightParen, current.ToString()));
                        break;
                    default:
                        throw new Exception($"Unexpected character: {current}");
                }

                _position++;
            }

            tokens.Add(new Token(TokenType.EndOfInput, ""));
            return tokens;
        }

        private Token ReadNumber()
        {
            var sb = new StringBuilder();
            while (_position < _input.Length && char.IsDigit(_input[_position]))
            {
                sb.Append(_input[_position]);
                _position++;
            }
            return new Token(TokenType.Number, sb.ToString());
        }
    }
}
