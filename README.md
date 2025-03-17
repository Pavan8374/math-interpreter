# Math Expression Interpreter

## 🚀 Overview
This project is a simple **Math Expression Interpreter** implemented in C# using core components of a programming language:
- **Lexer** – Converts input into tokens  
- **Parser** – Builds an Abstract Syntax Tree (AST)  
- **Interpreter** – Evaluates the AST using native bitwise operations  

The goal of this project is to explore **compiler design** and achieve **native-level execution** for mathematical operations (addition, subtraction, multiplication, and division). 

---

## 🎯 **Project Structure**

📂 MathExpressionInterpreter ├── 📄 Lexer.cs ├── 📄 Parser.cs ├── 📄 ASTNode.cs ├── 📄 Interpreter.cs ├── 📄 Program.cs └── 📄 Token.cs


### 1. **Lexer.cs**  
- Converts input string into a list of tokens.  
- Handles numeric values and operators (`+`, `-`, `*`, `/`).  

### 2. **Parser.cs**  
- Converts the token list into an **Abstract Syntax Tree (AST)**.  
- Handles operator precedence and associativity.  

### 3. **AST.cs**  
- Defines the node structure for the syntax tree.  
- Supports `BinaryOperationNode` and `NumberNode`.  

### 4. **Interpreter.cs**  
- Evaluates the AST using **bitwise native operations** for:  
  ✅ Addition  
  ✅ Subtraction  
  ✅ Multiplication  
  ✅ Division  

### 5. **Program.cs**  
- Entry point of the project.  
- Accepts user input and prints the result.  

---

## 🧠 **Key Achievements**
### ✅ **Native-Level Execution for Arithmetic Operations**  
We’ve implemented the following operations using **low-level bitwise logic** that directly reflects how the CPU works:

| Operation | Implementation Method | Achieved Native-Level Execution |
|-----------|------------------------|---------------------------------|
| **Addition** | `AND`, `XOR`, `SHIFT` | ✅ Yes |
| **Subtraction** | Two's complement + bitwise ops | ✅ Yes |
| **Multiplication** | Shift + addition loop | ✅ Yes |
| **Division** | Shift + subtraction loop | ✅ Yes |

### ✅ **Direct CPU-Level Logic**  
- Bitwise operations (`AND`, `XOR`, `SHIFT`) are mapped directly to CPU instructions.  
- Similar to how low-level languages like **C** and **Assembly** handle arithmetic.  

### ✅ **Recursive Parsing with AST**  
- Constructed a recursive descent parser.  
- Handles operator precedence and associativity.  

---

## ❌ **What’s NOT Native-Level Yet**
| Component | Current State | How to Improve |
|-----------|---------------|----------------|
| **Memory Management** | Managed by .NET GC | Use `unsafe` or `stackalloc` |
| **Type System** | Managed by .NET | Use `int*` or `byte[]` |
| **Exception Handling** | Uses C# exceptions | Return error codes |
| **Function Calls** | Managed by .NET | Use `ILGenerator` or direct P/Invoke |

---

## 🚧 **Future Improvements**
1. ✅ Switch to `unsafe` context to manage memory directly.  
2. ✅ Remove `Exception` handling and switch to error codes.  
3. ✅ Inline function calls using direct memory manipulation.  
4. ✅ Experiment with `ILGenerator` to dynamically generate native code.  

---

## 🏁 **How to Run**
1. Clone the repository:  

git clone https://github.com/rpa1k/MathExpressionInterpreter.git

2. Build and run:

dotnet run
	
3. Enter a math expression like:

3 + 5 * (2 - 1)

👨‍💻 How It Works
1. Lexer splits input into tokens.
2. Parser builds an AST from tokens.
3. Interpreter evaluates the AST using bitwise operations.
4. Result is printed to the console.

🌟 Why This Project Matters
✅ It demonstrates how programming languages internally handle arithmetic.
✅ Uses native-level bitwise operations for better performance and deeper understanding.
✅ Explores compiler and interpreter design fundamentals.

❤️ Contributions
If you find this project helpful, feel free to fork, contribute, and raise a PR!

🔥 Author
Rambhukta Pavan Kumar
Backend Engineer | Low-Level Enthusiast | Open Source Contributor


🚀 Happy Hacking! 😎

---





