namespace MathInterpreter
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.Write("Enter expression (or 'exit' to quit): ");
                var input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input) || input.ToLower() == "exit")
                    break;

                try
                {
                    var lexer = new Lexer(input);
                    var tokens = lexer.Tokenize();

                    var parser = new Parser(tokens);
                    var ast = parser.Parse();

                    var interpreter = new Interpreter(ast);
                    var result = interpreter.Interpret();

                    Console.WriteLine($"Result: {result}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                Console.WriteLine();
            }
        }
    }
}
