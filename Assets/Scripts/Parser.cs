using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Parsing
{

    public class Parser : MonoBehaviour
    {
        #region InOut

        public Text outputText;
        public Text inputField;
        public string inputString;
        public string outputString;

        #endregion

        #region Parseing

        public delegate double OperatorDelegate(double num1, double num2);
        public static Dictionary<char, OperatorDelegate> Operators;
        public static char[] OperatorOrder;

        public delegate double FunctionDelegate(double[] arguments);
        public static Dictionary<string, FunctionDelegate> Functions;

        #endregion


        // Use this for initialization
        void Start()
        {
            Math<double>.StartMathKernel();

            Operators = new Dictionary<char, OperatorDelegate>();
            OperatorOrder = new char[] { '^', '%', '*', '/', '+', '-' };
            Operators['^'] = Operator.PowerOperator;
            Operators['%'] = Operator.ModulusOperator;
            Operators['*'] = Operator.TimesOperator;
            Operators['/'] = Operator.DivideOperator;
            Operators['+'] = Operator.PlusOperator;
            Operators['-'] = Operator.MinusOperator;
            Functions = new Dictionary<string, FunctionDelegate>();
            Functions["sin"] = Function.Sin;
            Functions["cos"] = Function.Cos;
            Functions["tan"] = Function.Tan;
            Functions["csc"] = Function.Csc;
            Functions["sec"] = Function.Sec;
            Functions["cot"] = Function.Cot;
            Functions["log"] = Function.Log;
            Functions["sqrt"] = Function.Sqrt;
            Functions["ln"] = Function.Ln;
            Functions["pi"] = Function.Pi;
            Functions["abs"] = Function.Abs;
            Functions["sign"] = Function.Sign;
            Functions["floor"] = Function.Floor;
            Functions["ceil"] = Function.Ceil;
            Functions["round"] = Function.Round;
            Functions["mean"] = Function.Mean;
            Functions["mode"] = Function.Mode;
            Functions["median"] = Function.Median;
            Functions["var"] = Function.Var;
            Functions["varp"] = Function.Varp;
            Functions["stdev"] = Function.StDev;
            Functions["stdevp"] = Function.StDevp;
            Functions["madmean"] = Function.MadMean;
            Functions["madmode"] = Function.MadMode;
            Functions["madmedian"] = Function.MadMedian;
            Functions["min"] = Function.Min;
            Functions["max"] = Function.Max;
            Functions["range"] = Function.Range;
            Functions["ncr"] = Function.nCr;
            Functions["npr"] = Function.nPr;
            Functions["factorial"] = Function.Factorial;
        }

        // Update is called once per frame
        void Update()
        {
            inputString = inputField.text;
            outputText.text = outputString;
        }

        public void Calculate()
        {
            outputString = Parse(inputString);
        }

        public static string Parse(string expression)
        {
            try
            {
                Tokenizer tokenizer = new Tokenizer(expression);
                return tokenizer.RootToken.Parse().ToString();
            }
            catch (ExpressionParseException e)
            {
                return "Error: " + e.Message + "!";
            }
        }
    }

    public class Operator
    {
        public static double PlusOperator(double num1, double num2)
        {
            return num1 + num2;
        }

        public static double MinusOperator(double num1, double num2)
        {
            return num1 - num2;
        }

        public static double TimesOperator(double num1, double num2)
        {
            return num1 * num2;
        }

        public static double DivideOperator(double num1, double num2)
        {
            return num1 / num2;
        }

        public static double ModulusOperator(double num1, double num2)
        {
            return num1 % num2;
        }

        public static double PowerOperator(double num1, double num2)
        {
            return Math<double>.Power(num1, num2);
        }
    }

    public class Function
    {
        public static double Pi(double[] argumetns)
        {
            //if (argumetns.Length != 0)
                //throw new ExpressionParseException("Pi takes zero arguments, " + argumetns.Length + " given.");
            return Math<Double>.pi;
        }
        
        public static double Sin(double[] arguments)
        {
            if (arguments.Length != 1)
                throw new ExpressionParseException("Sin takes one argument, " + arguments.Length + " given.");
            return Math<double>.Sin(arguments[0]);
        }

        public static double Cos(double[] arguments)
        {
            if (arguments.Length != 1)
                throw new ExpressionParseException("Cos takes one argument, " + arguments.Length + " given.");
            return Math<double>.Cos(arguments[0]);
        }

        public static double Tan(double[] arguments)
        {
            if (arguments.Length != 1)
                throw new ExpressionParseException("Tan takes one argument, " + arguments.Length + " given.");
            return Math<double>.Tan(arguments[0]);
        }

        public static double Csc(double[] arguments)
        {
            if (arguments.Length != 1)
                throw new ExpressionParseException("Csc takes one argument, " + arguments.Length + " given.");
            return Math<double>.Csc(arguments[0]);
        }

        public static double Sec(double[] arguments)
        {
            if (arguments.Length != 1)
                throw new ExpressionParseException("Sec takes one argument, " + arguments.Length + " given.");
            return Math<double>.Sec(arguments[0]);
        }

        public static double Cot(double[] arguments)
        {
            if (arguments.Length != 1)
                throw new ExpressionParseException("Cot takes one argument, " + arguments.Length + " given.");
            return Math<double>.Cot(arguments[0]);
        }

        public static double Log(double[] arguments)
        {
            if (arguments.Length != 2)
                throw new ExpressionParseException("Log takes two arguments, " + arguments.Length + " given.");
            return Math<double>.Log(arguments[0], arguments[1]);
        }

        public static double Ln(double[] arguments)
        {
            if (arguments.Length != 1)
                throw new ExpressionParseException("Ln takes one arguments, " + arguments.Length + " given.");
            return Math<double>.Ln(arguments[0]);
        }

        public static double Sqrt(double[] arguments)
        {
            if (arguments.Length != 1)
                throw new ExpressionParseException("Sqrt takes one argument, " + arguments.Length + " given.");
            return Math<double>.Sqrt(arguments[0]);
        }

        public static double Abs(double[] arguments)
        {
            if (arguments.Length != 1)
                throw new ExpressionParseException("Abs takes one argument, " + arguments.Length + " given.");
            return Math<double>.AbsoluteValue(arguments[0]);
        }

        public static double Sign(double[] arguments)
        {
            if (arguments.Length != 1)
                throw new ExpressionParseException("Sign takes one argument, " + arguments.Length + " given.");
            return Math<double>.Sign(arguments[0]);
        }

        public static double Floor(double[] arguments)
        {
            if (arguments.Length != 1)
                throw new ExpressionParseException("Floor takes one argument, " + arguments.Length + " given.");
            return Math<double>.Floor(arguments[0]);
        }

        public static double Ceil(double[] arguments)
        {
            if (arguments.Length != 1)
                throw new ExpressionParseException("Ceil takes one argument, " + arguments.Length + " given.");
            return Math<double>.Ceil(arguments[0]);
        }

        public static double Round(double[] arguments)
        {
            if (arguments.Length != 1)
                throw new ExpressionParseException("Round takes one argument, " + arguments.Length + " given.");
            return Math<double>.Round(arguments[0]);
        }

        public static double Mean(double[] arguments)
        {
            return Math<double>.Mean(arguments);
        }

        public static double Mode(double[] arguments)
        {
            return Math<double>.Mode(arguments);
        }

        public static double Median(double[] arguments)
        {
            return Math<double>.Median(arguments);
        }

        public static double Var(double[] arguments)
        {
            return Math<double>.Var(arguments);
        }

        public static double Varp(double[] arguments)
        {
            return Math<double>.Varp(arguments);
        }

        public static double StDev(double[] arguments)
        {
            return Math<double>.StDev(arguments);
        }

        public static double StDevp(double[] arguments)
        {
            return Math<double>.StDevp(arguments);
        }

        public static double MadMean(double[] arguments)
        {
            return Math<double>.MadMean(arguments);
        }

        public static double MadMedian(double[] arguments)
        {
            return Math<double>.MadMedian(arguments);
        }

        public static double MadMode(double[] arguments)
        {
            return Math<double>.MadMode(arguments);
        }

        public static double Min(double[] arguments)
        {
            return Math<double>.Min(arguments);
        }

        public static double Max(double[] arguments)
        {
            return Math<double>.Max(arguments);
        }

        public static double Range(double[] arguments)
        {
            return Math<double>.Range(arguments);
        }

        public static double nCr(double[] arguments)
        {
            if (arguments.Length != 2)
                throw new ExpressionParseException("nCr takes two arguments, " + arguments.Length + " given.");
            return Math<double>.nCr((int)arguments[0], (int)arguments[1]);
        }

        public static double nPr(double[] arguments)
        {
            if (arguments.Length != 2)
                throw new ExpressionParseException("nPr takes two arguments, " + arguments.Length + " given.");
            return Math<double>.nPr((int)arguments[0], (int)arguments[1]);
        }

        public static double Factorial(double[] arguments)
        {
            if (arguments.Length != 1)
                throw new ExpressionParseException("Factorial takes one arguments, " + arguments.Length + " given.");
            return Math<double>.Factorial((int)arguments[0]);
        }
    }

    public class Tokenizer
    {
        public Token RootToken;
        private Token currentToken;

        public Tokenizer(string input)
        {
            RootToken = currentToken = new Token(TokenType.Root, "", null);
            StringReader reader = new StringReader(input);
            while (true)
            {
                int nextCharNum = reader.Read();
                if (nextCharNum == -1) //end of expression
                {
                    RootToken.AddChild(new Token(TokenType.EOF, "", null));
                    break;
                }
                char nextChar = (char)nextCharNum;
                if (Char.IsWhiteSpace(nextChar)) continue;
                if (Char.IsNumber(nextChar) || (nextChar == '-' && Char.IsNumber((char)reader.Peek()))) //number, or minus sign before number
                {
                    string fullNum = nextChar.ToString();
                    while (Char.IsNumber((char)reader.Peek()) || (char)reader.Peek() == '.')
                        fullNum += (char)reader.Read(); //get the full number
                    double temp;
                    if (!double.TryParse(fullNum, out temp))
                        throw new ExpressionParseException(fullNum + " is not a valid number");
                    Token t = new Token(TokenType.Number, fullNum, currentToken);
                    currentToken.AddChild(t);
                }
                else if (Parser.Operators.ContainsKey(nextChar)) //operator
                {
                    Token t = new Token(TokenType.Operator, nextChar.ToString(), currentToken);
                    currentToken.AddChild(t);
                }
                else if (nextChar == ')') //end of function or group
                {
                    currentToken = currentToken.Parent;
                }
                else if (nextChar == '(') //open of group
                {
                    Token t = new Token(TokenType.Group, "", currentToken);
                    currentToken.AddChild(t);
                    currentToken = t;
                }
                else if (nextChar == ',')
                {
                    if (currentToken.Type == TokenType.Root)
                        throw new ExpressionParseException("Argument seperator while not in function");
                    Token t = new Token(TokenType.ArgSep, "", currentToken);
                    currentToken.AddChild(t);
                }
                else
                {
                    string functionName = nextChar.ToString();
                    while (true)
                    {
                        int c = reader.Peek();
                        if (c == -1)
                            throw new ExpressionParseException("End of string present before function end");
                        if ((char)c == '(') // function name end, start of args
                            break;
                        functionName += (char)reader.Read();
                    }
                    if (!Parser.Functions.ContainsKey(functionName))
                        throw new ExpressionParseException("Unknown function '" + functionName + "'");
                    Token t = new Token(TokenType.Function, functionName, currentToken);
                    currentToken.AddChild(t);
                    currentToken = t;
                }
            }
        }
    }

    public class Token
    {
        private List<Token> children;
        private Token parent;
        private TokenType type;
        private string value;

        public Token(TokenType type, string value, Token parent)
        {
            this.children = new List<Token>();
            this.type = type;
            this.parent = parent;
            this.value = value;
        }

        public void AddChild(Token child)
        {
            this.children.Add(child);
        }

        public double Parse()
        {
            if (this.Type == TokenType.Number)
                return double.Parse(this.Value);
            double value = 0;
            double childValue = 0;
            List<Token> tree = new List<Token>(); //add everything to a new tree to go through later;
            foreach (Token child in children) //first, we compute child functions, groups, and numbers
            {
                switch (child.Type)
                {
                    case TokenType.Function:
                    case TokenType.Number:
                    case TokenType.Group:
                        tree.Add(new Token(TokenType.Number, child.Parse().ToString(), null));
                        break;
                    default:
                        tree.Add(child);
                        break;
                }
            }
            //now an expression like cos(sin(5) + (sqrt(43) + 4 * 7) + 4) looks like cos(-0.95892427466 + 34.5574385243 + 4)
            int resultLocation = 0;
            foreach (char op in Parser.OperatorOrder) // order of operations? sure
            {
                for (int i = 0; i < tree.Count; i++)
                {
                    Token child = tree[i];
                    if (child.Value == op.ToString()) //one operator at a time
                    {
                        int prevLocation = i - 1;
                        int nextLocation = i + 1;
                        if (tree[i + 1].Type == TokenType.Pointer)
                            nextLocation = int.Parse(tree[i + 1].Value); // this is probably the worst way to do it
                        if (tree[i - 1].Type == TokenType.Pointer)
                            prevLocation = int.Parse(tree[i - 1].Value);
                        if (i == 0) //no number before operator
                            throw new ExpressionParseException("Operator found without a preceding number");
                        if (i == tree.Count - 1)
                            throw new ExpressionParseException("Operator found at end of string");
                        if (tree[prevLocation].Type != TokenType.Number || tree[nextLocation].Type != TokenType.Number)
                            throw new ExpressionParseException("Invalid operator placement; one or both parameters are not numbers!");
                        double result = Parser.Operators[child.Value[0]](double.Parse(tree[prevLocation].Value), double.Parse(tree[nextLocation].Value));
                        tree[i + 1].value = result.ToString();
                        tree[i].type = tree[i - 1].type = TokenType.Pointer; //these tokens now point to the true value, in i + 1
                        tree[i].value = tree[i - 1].value = (i + 1).ToString();
                        resultLocation = i + 1;
                    }
                }
            }
            if (tree.Count > 0)
                childValue = double.Parse(tree[resultLocation].Value);
            // now we have cos(37.5985142496)
            if (type == TokenType.Function)
            {
                List<Token> arguments = new List<Token>();
                for (int i = 0; i < tree.Count; i++)
                {
                    Token child = tree[i];
                    if (child.Type == TokenType.ArgSep)
                        continue;
                    if (tree.Count > 1 && tree[i + 1].Type != TokenType.ArgSep)
                        throw new ExpressionParseException("Number found, expected argument seperator");
                    arguments.Add(child);
                }
                double[] args = new double[arguments.Count];
                for (int j = 0; j < args.Length; j++)
                    args[j] = double.Parse(arguments[j].Value);
                value = Parser.Functions[this.value](args);
            }
            else
                value = childValue;
            return value;
        }

        public TokenType Type
        {
            get { return this.type; }
        }

        public Token Parent
        {
            get { return parent; }
        }

        public Token[] Children
        {
            get { return this.children.ToArray(); }
        }

        public string Value
        {
            get { return this.value; }
        }
    }

    public enum TokenType
    {
        Number,
        Operator,
        Function,
        EOF,
        Group,
        ArgSep,
        Pointer,
        Root
    }

    public class ExpressionParseException : System.Exception
    {
        public ExpressionParseException() : base() { }
        public ExpressionParseException(string message) : base(message) { }
    }
}