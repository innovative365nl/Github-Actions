// See https://aka.ms/new-console-template for more information

using System.Text;
using NamingConvention;

if (args.Length <= 0) throw new ArgumentException("Please supply arguments.");
//test comment

const string path             = "unknown";
const string argumentErrorStr = "Please supply arguemnt: `{0}` to action.";

var folderName = args[1];
if (string.IsNullOrEmpty(folderName) || folderName.Equals(path))
    throw new ArgumentException(string.Format(argumentErrorStr, path));

var environment = args[3];
if (string.IsNullOrEmpty(environment) || environment.Equals(path))
    throw new ArgumentException(string.Format(argumentErrorStr, path));
environment = environment.Remove(1);

var product = args[5];
if (string.IsNullOrEmpty(product) || product.Equals(path))
    throw new ArgumentException(string.Format(argumentErrorStr, path));
product = product.Remove(8);

var logic = folderName.Split(".")[1];
var type  = InputHelper.ReturnType(folderName: ref folderName, argumentErrorStr: argumentErrorStr);

var folder = folderName.Split(".")[0];
var rgName = $"{environment}-{product}-Rg-Weu";
var apimName = $"{environment}-{product}-Portal-Management-Apim-Weu";
var apiId = $"{type.Remove(4)}-{logic}";
var apiPath = $"{type.ToLower()}/{logic.ToLower()}";
var functionName = $"{environment}-{product}-{type.Remove(4)}-{logic}-Func-01-Weu";


var gitHubOutputFile = Environment.GetEnvironmentVariable("GITHUB_OUTPUT");
if (!string.IsNullOrWhiteSpace(gitHubOutputFile))
{
    await using StreamWriter textWriter = new(gitHubOutputFile, true, Encoding.UTF8);
    textWriter.WriteLine($"FolderName={folder}");
    textWriter.WriteLine($"RgName={rgName}");
    textWriter.WriteLine($"ApimName={apimName}");
    textWriter.WriteLine($"ApiId={apiId}");
    textWriter.WriteLine($"ApiPath={apiPath}");
    textWriter.WriteLine($"FunctionName={functionName}");
}

await ValueTask.CompletedTask;

Environment.Exit(0);


