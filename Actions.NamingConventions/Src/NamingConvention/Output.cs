namespace NamingConvention;

/// <summary>
/// Represents the output of naming convention generation containing various Azure resource names
/// </summary>
public class Output
{
    public string Folder { get; init; }
    public string RgName { get; init; }
    public string ApimName { get; init; }
    public string ApiId { get; init; }
    public string ApiPath { get; init; }
    public string FunctionName { get; init; }
    public string WebAppName { get; init; }
}