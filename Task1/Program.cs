using System;

class Task1
{
    private static void Main()
    {
        var data = new List<string>()
        {
            "(((){}[]]]])(",        //false
            "(){}[][][]()",         //true
            "({[]})()[]"            //true
        };
        foreach (var str in data)
        {
            Console.WriteLine(IsValidBraces(str));
        }
    }
    private static bool IsValidBraces(string braces) {
        var stack = new Stack<char>();
        foreach (var brace in braces)
        {
            if (stack.Count > 0)
            {
                if ((brace == ']' && stack.Peek() == '[')
                    || (brace == '}' && stack.Peek() == '{')
                    || (brace == ')' && stack.Peek() == '('))
                    stack.Pop();
            }
            else stack.Push(brace);
        }
        return stack.Count == 0;
    }
}