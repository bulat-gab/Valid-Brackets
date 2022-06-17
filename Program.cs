// String [{()}]
// { ( } ) 

// curlyBrackets: 1; parenthesis: 1

bool isCorrect(string input)
{
    if (string.IsNullOrEmpty(input))
    {
        return false;
    }

    var curlyBrackets = 0;
    var squareBrackets = 0;
    var roundBrackets = 0;

    for (int i = 0; i < input.Length; i++)
    {
        if (i == 0)
        {
            if (input[i] == ')' || input[i] == '}' || input[i] == ']')
            {
                return false;
            }
        }

        switch (input[i])
        {
            case '{':
                curlyBrackets++;
                break;
            case '[':
                squareBrackets++;
                break;
            case '(':
                roundBrackets++;
                break;
        }

        if (input[i] == '}')
        {
            if (input[i - 1] != '{')
            {
                return false;
            }

            curlyBrackets--;
        }
        if (input[i] == ']')
        {
            if (input[i - 1] != '[')
            {
                return false;
            }

            squareBrackets--;
        }
        if (input[i] == ')')
        {
            if (input[i - 1] != '(')
            {
                return false;
            }

            roundBrackets--;
        }
    }

    return squareBrackets == 0 && curlyBrackets == 0 && roundBrackets == 0;
}

Console.WriteLine(isCorrect("[{()}]"));