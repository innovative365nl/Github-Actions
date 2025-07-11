namespace NamingConvention;

public class AutomateInputHelper
{
    public static Output ReturnOutput(ref string folderName, string environment, string product, string argumentErrorStr)
    {
        var folder = folderName.Split(".")[0];
        var logic = folderName.Split(".")[2];
        var type = InputHelper.ReturnType(folderName: ref folderName, argumentErrorStr: argumentErrorStr);
        var rgName = $"{environment}-{product}-Rg-Weu";
        var apimName = $"{environment}-{product}-Portal-Management-Apim-Weu";
        var apiId = $"{GetShortNames(type)}-{logic}";
        var apiPath = $"{type.ToLower()}/{logic.ToLower()}";
        var functionName = $"{environment}-{product}-{type}-{logic}-Func-01-Weu";
        var webAppName = $"{environment}-{product}-{type}-{logic}-webApp-Weu";
        
        return new Output
        {
            Folder = folder,
            RgName = rgName,
            ApimName = apimName,
            ApiId = apiId,
            ApiPath = apiPath,
            FunctionName = functionName,
            WebAppName = webAppName,
        };
    }
    
    private static string GetShortNames(string input, int maxCharacters = 4)
    {
        if (input.Length > maxCharacters)
            return input.Substring(0, maxCharacters);
        else
            return input;
    }
}