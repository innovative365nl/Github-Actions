namespace NamingConvention;

public class DefaultInputHelper
{
    public static Output ReturnOutput(ref string folderName, string environment, string product, string argumentErrorStr)
    {

        var logic = folderName.Split(".")[1];

        var type = InputHelper.ReturnType(folderName: ref folderName, argumentErrorStr: argumentErrorStr);

        var rgName = $"{environment}-{product}-Rg-Weu";
        var apimName = $"{environment}-{product}-Portal-Management-Apim-Weu";
        var apiId = $"{type[..4]}-{logic}";
        var apiPath = $"{type.ToLower()}/{logic.ToLower()}";

        //temporary change
        if (type == "Portal")
        {
        }
        else if (type == "Connectors")
            type = "Conn";
        else
            type = type[..4];

        var functionName = $"{environment}-{product}-{type}-{logic}-Func-01-Weu";
        var webAppName = $"{environment}-{product}-{type}-{logic}-webApp-Weu";

        return new Output
        {
            Folder = folderName,
            RgName = rgName,
            ApimName = apimName,
            ApiId = apiId,
            ApiPath = apiPath,
            FunctionName = functionName,
            WebAppName = webAppName,
        };
    }
}