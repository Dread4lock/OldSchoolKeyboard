using System.Text;

var a = OldPhonePad(Console.ReadLine());
Console.WriteLine(a);
Console.ReadLine();

static string OldPhonePad(string input)
{  
    Dictionary<char, string> keypad = new Dictionary<char, string>
    {
        { '1', "&`(" },
        { '2', "ABC" },
        { '3', "DEF" },
        { '4', "GHI" },
        { '5', "JKL" },
        { '6', "MNO" },
        { '7', "PQRS" },
        { '8', "TUV" },
        { '9', "WXYZ" },
        { '0', " " }
    };

    StringBuilder result = new StringBuilder();
    int pressCount = 0;
    /* 
     * I assumed that Turing is a hint to solve, so, there is my decoding of your Enigma with 
     using the Tuning Machine approach
    */
    char lastKey = ' ';    
     
    foreach (char key in input)
    {
        if (key == '#')   
        {
            break;
        }
        else if (key == '*')   
        {
            if (result.Length > 0)
            {
                result.Remove(result.Length - 1, 1);   
            }
            lastKey = ' ';  
            pressCount = 0;  
        }
        else if (key == lastKey)   
        {
            pressCount++;   
        }
        else  
        {
            if (lastKey != ' ')   
            { 
                string letters = keypad[lastKey];
                result.Append(letters[(pressCount - 1) % letters.Length]);
            } 
            lastKey = key;
            pressCount = 1;   
        }
    }
    return result.ToString();
}
