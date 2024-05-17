
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF           =  0, // (EOF)
        SYMBOL_ERROR         =  1, // (Error)
        SYMBOL_WHITESPACE    =  2, // Whitespace
        SYMBOL_MINUS         =  3, // '-'
        SYMBOL_MINUSMINUS    =  4, // '--'
        SYMBOL_EXCLAMEQ      =  5, // '!='
        SYMBOL_LPAREN        =  6, // '('
        SYMBOL_RPAREN        =  7, // ')'
        SYMBOL_TIMES         =  8, // '*'
        SYMBOL_DIV           =  9, // '/'
        SYMBOL_SEMI          = 10, // ';'
        SYMBOL_CARET         = 11, // '^'
        SYMBOL_LBRACE        = 12, // '{'
        SYMBOL_LBRACELBRACE  = 13, // '{{'
        SYMBOL_RBRACE        = 14, // '}'
        SYMBOL_RBRACERBRACE  = 15, // '}}'
        SYMBOL_PLUS          = 16, // '+'
        SYMBOL_PLUSPLUS      = 17, // '++'
        SYMBOL_LT            = 18, // '<'
        SYMBOL_EQ            = 19, // '='
        SYMBOL_EQEQ          = 20, // '=='
        SYMBOL_GT            = 21, // '>'
        SYMBOL_BYE           = 22, // Bye
        SYMBOL_CALL          = 23, // call
        SYMBOL_DIGIT         = 24, // Digit
        SYMBOL_ELSE          = 25, // else
        SYMBOL_FOR           = 26, // for
        SYMBOL_FUNCTION      = 27, // function
        SYMBOL_HELLO         = 28, // Hello
        SYMBOL_ID            = 29, // Id
        SYMBOL_IF            = 30, // if
        SYMBOL_START         = 31, // Start
        SYMBOL_ASSIGN        = 32, // <assign>
        SYMBOL_CONCEPT       = 33, // <concept>
        SYMBOL_COND          = 34, // <cond>
        SYMBOL_DIGIT2        = 35, // <digit>
        SYMBOL_EXP           = 36, // <exp>
        SYMBOL_EXPRETION     = 37, // <expretion>
        SYMBOL_FACTOR        = 38, // <factor>
        SYMBOL_FOR2          = 39, // <for>
        SYMBOL_ID2           = 40, // <id>
        SYMBOL_IF_STMT       = 41, // <if_stmt>
        SYMBOL_METHOD        = 42, // <method>
        SYMBOL_METHODCALL    = 43, // <method call>
        SYMBOL_NAMEMETHOD    = 44, // <name method>
        SYMBOL_OP            = 45, // <op>
        SYMBOL_PROGRAM       = 46, // <program>
        SYMBOL_STATMENT_LIST = 47, // <statment_list>
        SYMBOL_STEP          = 48, // <step>
        SYMBOL_TERM          = 49  // <term>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAM_HELLO                                            =  0, // <program> ::= Hello <statment_list>
        RULE_PROGRAM_BYE                                              =  1, // <program> ::= <method> Bye
        RULE_STATMENT_LIST                                            =  2, // <statment_list> ::= <concept>
        RULE_STATMENT_LIST2                                           =  3, // <statment_list> ::= <concept> <statment_list>
        RULE_STATMENT_LIST3                                           =  4, // <statment_list> ::= <method call>
        RULE_CONCEPT                                                  =  5, // <concept> ::= <assign>
        RULE_CONCEPT2                                                 =  6, // <concept> ::= <if_stmt>
        RULE_CONCEPT3                                                 =  7, // <concept> ::= <for>
        RULE_ASSIGN_EQ_SEMI                                           =  8, // <assign> ::= <id> '=' <expretion> ';'
        RULE_ASSIGN_EQ_SEMI2                                          =  9, // <assign> ::= <digit> '=' <expretion> ';'
        RULE_ID_ID                                                    = 10, // <id> ::= Id
        RULE_EXPRETION_PLUS                                           = 11, // <expretion> ::= <expretion> '+' <term>
        RULE_EXPRETION_MINUS                                          = 12, // <expretion> ::= <expretion> '-' <term>
        RULE_EXPRETION                                                = 13, // <expretion> ::= <term>
        RULE_TERM_TIMES                                               = 14, // <term> ::= <term> '*' <factor>
        RULE_TERM_DIV                                                 = 15, // <term> ::= <term> '/' <factor>
        RULE_TERM                                                     = 16, // <term> ::= <factor>
        RULE_FACTOR_CARET                                             = 17, // <factor> ::= <factor> '^' <exp>
        RULE_FACTOR                                                   = 18, // <factor> ::= <exp>
        RULE_EXP_LPAREN_RPAREN                                        = 19, // <exp> ::= '(' <expretion> ')'
        RULE_EXP                                                      = 20, // <exp> ::= <id>
        RULE_EXP2                                                     = 21, // <exp> ::= <digit>
        RULE_DIGIT_DIGIT                                              = 22, // <digit> ::= Digit
        RULE_IF_STMT_IF_LPAREN_RPAREN_START_SEMI                      = 23, // <if_stmt> ::= if '(' <cond> ')' Start <statment_list> ';'
        RULE_IF_STMT_IF_LPAREN_RPAREN_START_SEMI_ELSE                 = 24, // <if_stmt> ::= if '(' <cond> ')' Start <statment_list> ';' else <statment_list>
        RULE_COND                                                     = 25, // <cond> ::= <expretion> <op> <expretion>
        RULE_OP_LT                                                    = 26, // <op> ::= '<'
        RULE_OP_GT                                                    = 27, // <op> ::= '>'
        RULE_OP_EQEQ                                                  = 28, // <op> ::= '=='
        RULE_OP_EXCLAMEQ                                              = 29, // <op> ::= '!='
        RULE_FOR_FOR_LPAREN_ID_SEMI_SEMI_RPAREN_LBRACE_RBRACE         = 30, // <for> ::= for '(' Id ';' <cond> ';' <step> ')' '{' <statment_list> '}'
        RULE_STEP_MINUSMINUS                                          = 31, // <step> ::= '--' <id>
        RULE_STEP_MINUSMINUS2                                         = 32, // <step> ::= <id> '--'
        RULE_STEP_PLUSPLUS                                            = 33, // <step> ::= <id> '++'
        RULE_STEP_PLUSPLUS2                                           = 34, // <step> ::= '++' <id>
        RULE_STEP                                                     = 35, // <step> ::= <assign>
        RULE_METHOD_FUNCTION_LPAREN_RPAREN_LBRACELBRACE_RBRACERBRACE  = 36, // <method> ::= function <name method> '(' <assign> ')' '{{' <statment_list> '}}'
        RULE_METHOD_FUNCTION_LPAREN_RPAREN_LBRACELBRACE_RBRACERBRACE2 = 37, // <method> ::= function <name method> '(' ')' '{{' <statment_list> '}}'
        RULE_NAMEMETHOD                                               = 38, // <name method> ::= <id>
        RULE_NAMEMETHOD2                                              = 39, // <name method> ::= <digit>
        RULE_METHODCALL_FUNCTION_CALL_LPAREN_RPAREN                   = 40, // <method call> ::= function call <name method> '(' ')'
        RULE_METHODCALL_FUNCTION_CALL_LPAREN_RPAREN2                  = 41  // <method call> ::= function call <name method> '(' <digit> ')'
    };

    public class MyParser
    {
        private LALRParser parser;

        public MyParser(string filename)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUSMINUS :
                //'--'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAMEQ :
                //'!='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SEMI :
                //';'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CARET :
                //'^'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACE :
                //'{'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACELBRACE :
                //'{{'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACE :
                //'}'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACERBRACE :
                //'}}'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUSPLUS :
                //'++'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQEQ :
                //'=='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BYE :
                //Bye
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CALL :
                //call
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT :
                //Digit
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE :
                //else
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR :
                //for
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCTION :
                //function
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_HELLO :
                //Hello
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID :
                //Id
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //if
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_START :
                //Start
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGN :
                //<assign>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONCEPT :
                //<concept>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COND :
                //<cond>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIGIT2 :
                //<digit>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXP :
                //<exp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPRETION :
                //<expretion>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FACTOR :
                //<factor>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR2 :
                //<for>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ID2 :
                //<id>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF_STMT :
                //<if_stmt>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_METHOD :
                //<method>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_METHODCALL :
                //<method call>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NAMEMETHOD :
                //<name method>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OP :
                //<op>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM :
                //<program>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATMENT_LIST :
                //<statment_list>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STEP :
                //<step>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TERM :
                //<term>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAM_HELLO :
                //<program> ::= Hello <statment_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PROGRAM_BYE :
                //<program> ::= <method> Bye
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATMENT_LIST :
                //<statment_list> ::= <concept>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATMENT_LIST2 :
                //<statment_list> ::= <concept> <statment_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATMENT_LIST3 :
                //<statment_list> ::= <method call>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT :
                //<concept> ::= <assign>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT2 :
                //<concept> ::= <if_stmt>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONCEPT3 :
                //<concept> ::= <for>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGN_EQ_SEMI :
                //<assign> ::= <id> '=' <expretion> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGN_EQ_SEMI2 :
                //<assign> ::= <digit> '=' <expretion> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ID_ID :
                //<id> ::= Id
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRETION_PLUS :
                //<expretion> ::= <expretion> '+' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRETION_MINUS :
                //<expretion> ::= <expretion> '-' <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRETION :
                //<expretion> ::= <term>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_TIMES :
                //<term> ::= <term> '*' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM_DIV :
                //<term> ::= <term> '/' <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TERM :
                //<term> ::= <factor>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR_CARET :
                //<factor> ::= <factor> '^' <exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FACTOR :
                //<factor> ::= <exp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP_LPAREN_RPAREN :
                //<exp> ::= '(' <expretion> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP :
                //<exp> ::= <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXP2 :
                //<exp> ::= <digit>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DIGIT_DIGIT :
                //<digit> ::= Digit
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STMT_IF_LPAREN_RPAREN_START_SEMI :
                //<if_stmt> ::= if '(' <cond> ')' Start <statment_list> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IF_STMT_IF_LPAREN_RPAREN_START_SEMI_ELSE :
                //<if_stmt> ::= if '(' <cond> ')' Start <statment_list> ';' else <statment_list>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_COND :
                //<cond> ::= <expretion> <op> <expretion>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_LT :
                //<op> ::= '<'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_GT :
                //<op> ::= '>'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EQEQ :
                //<op> ::= '=='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OP_EXCLAMEQ :
                //<op> ::= '!='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FOR_FOR_LPAREN_ID_SEMI_SEMI_RPAREN_LBRACE_RBRACE :
                //<for> ::= for '(' Id ';' <cond> ';' <step> ')' '{' <statment_list> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_MINUSMINUS :
                //<step> ::= '--' <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_MINUSMINUS2 :
                //<step> ::= <id> '--'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_PLUSPLUS :
                //<step> ::= <id> '++'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP_PLUSPLUS2 :
                //<step> ::= '++' <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STEP :
                //<step> ::= <assign>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_METHOD_FUNCTION_LPAREN_RPAREN_LBRACELBRACE_RBRACERBRACE :
                //<method> ::= function <name method> '(' <assign> ')' '{{' <statment_list> '}}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_METHOD_FUNCTION_LPAREN_RPAREN_LBRACELBRACE_RBRACERBRACE2 :
                //<method> ::= function <name method> '(' ')' '{{' <statment_list> '}}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NAMEMETHOD :
                //<name method> ::= <id>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NAMEMETHOD2 :
                //<name method> ::= <digit>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_METHODCALL_FUNCTION_CALL_LPAREN_RPAREN :
                //<method call> ::= function call <name method> '(' ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_METHODCALL_FUNCTION_CALL_LPAREN_RPAREN2 :
                //<method call> ::= function call <name method> '(' <digit> ')'
                //todo: Create a new object using the stored tokens.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '"+args.UnexpectedToken.ToString()+"'";
            //todo: Report message to UI?
        }

    }
}
