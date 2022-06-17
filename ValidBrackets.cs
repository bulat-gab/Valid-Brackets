// String [{()}]
// { ( } ) 

// curlyBrackets: 1; parenthesis: 1

namespace ValidBrackets;

public class Program
{
    Dictionary<char, char> bracketsMapping = new Dictionary<char, char>
    {
        { ']', '[' },
        { '}', '{' },
        { ')', '(' },
    };

    public bool IsCorrect(string input)
    {
        var openingBrackets = new List<char> { '[', '{', '(' };
        var closingBrackets = new List<char> { ']', '}', ')' };

        if (string.IsNullOrEmpty(input))
            return false;

        var stack = new Stack<char>();
        foreach (char currentBracket in input)
        {
            if (openingBrackets.Contains(currentBracket))
            {
                stack.Push(currentBracket);
                continue;
            }
            else if (closingBrackets.Contains(currentBracket))
            {
                // The closing bracket does not have a corresponding opening bracket, i.e. the input is invalid.
                if (!stack.TryPop(out var previousBracket))
                {
                    return false;
                }

                // The closing and opening brackets do not match.
                if (bracketsMapping[currentBracket] != previousBracket)
                {
                    return false;
                }
            }
            // The input contains unexpected characters.
            else
            {
                return false;
            }
        }

        return stack.Count == 0;
    }
}