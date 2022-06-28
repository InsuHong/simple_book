using System;

public class Global_Func
{
    public string AddSlashes(string InputTxt)
    {
        // List of characters handled:
        // \000 null
        // \010 backspace
        // \011 horizontal tab
        // \012 new line
        // \015 carriage return
        // \032 substitute
        // \042 double quote
        // \047 single quote
        // \134 backslash
        // \140 grave accent

        string Result = InputTxt;
        try
        {
            Result = System.Text.RegularExpressions.Regex.Replace(InputTxt, @"[\000\010\011\012\015\032\042\047\134\140]", "\\$0");
        }
        catch (Exception Ex)
        {
            // handle any exception here
            Console.WriteLine(Ex.Message);
        }
        return Result;
    }

    public string SQLite_AddSlashes(string InputTxt)
    {
        // List of characters handled:
        // \000 null
        // \010 backspace
        // \011 horizontal tab
        // \012 new line
        // \015 carriage return
        // \032 substitute
        // \042 double quote
        // \047 single quote
        // \134 backslash
        // \140 grave accent

        string Result = InputTxt;
        try
        {
            //Result = System.Text.RegularExpressions.Regex.Replace(InputTxt, @"[\000\010\011\012\015\032\042\047\134\140]", "\\$0");
            Result = System.Text.RegularExpressions.Regex.Replace(InputTxt, @"[\000\010\011\012\015\032\042\134\140]", "\\$0");
            Result  = Result.Replace("'", "''");
        }
        catch (Exception Ex)
        {
            // handle any exception here
            Console.WriteLine(Ex.Message);
        }
        return Result;
    }









    public string StripSlashes(string InputTxt)
    {

        // List of characters handled:
        // \000 null
        // \010 backspace
        // \011 horizontal tab
        // \012 new line
        // \015 carriage return
        // \032 substitute
        // \042 double quote
        // \047 single quote
        // \134 backslash
        // \140 grave accent

        string Result = InputTxt;

        try
        {
            Result = System.Text.RegularExpressions.Regex.Replace(InputTxt, @"(\\)([\000\010\011\012\015\032\042\047\134\140])", "$2");
        }
        catch (Exception Ex)
        {
            // handle any exception here
            Console.WriteLine(Ex.Message);
        }
        return Result;
    }
}