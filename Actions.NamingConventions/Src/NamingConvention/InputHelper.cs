namespace NamingConvention;

public static class InputHelper
{
    public static string ReturnType(ref string folderName, string argumentErrorStr)
    {
        string type;
        if(folderName.Split(".")[0].ToLower() == "automate")
        {
            type = folderName.Split(".")[1]
        }
        else
             type = folderName.Split(".")[0];
        if (type.Equals("unknown"))
            throw new ArgumentException(string.Format(argumentErrorStr, type));
        else if (type.ToLower().Equals("orchestrators"))
        {
            type = "Orch";
        }
        return type;

    }
    
}
