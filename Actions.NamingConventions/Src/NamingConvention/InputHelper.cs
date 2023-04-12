namespace NamingConvention;

public static class InputHelper
{
    public static string ReturnType(ref string folderName, string argumentErrorStr)
    {
        var type = folderName.Split(".")[0];
        if (type.Equals("unknown"))
            throw new ArgumentException(string.Format(argumentErrorStr, type));
        else if (type.ToLower().Equals("orchestrators"))
        {
            type = "Orch";
        }
        return type;

    }
    
}