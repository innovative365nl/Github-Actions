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

Output output = folderName switch
{
    _ when folderName.StartsWith("Automate") => AutomateInputHelper.ReturnOutput(folderName: ref folderName,
        environment: environment, product: product, argumentErrorStr: argumentErrorStr),
    _ => DefaultInputHelper.ReturnOutput(folderName: ref folderName, environment: environment, product: product, argumentErrorStr: argumentErrorStr)
};

var gitHubOutputFile = Environment.GetEnvironmentVariable("GITHUB_OUTPUT");
if (!string.IsNullOrWhiteSpace(gitHubOutputFile))
{
    await using StreamWriter textWriter = new(gitHubOutputFile, true, Encoding.UTF8);
    textWriter.WriteLine($"FolderName={output.Folder}");
    textWriter.WriteLine($"RgName={output.RgName}");
    textWriter.WriteLine($"ApimName={output.ApimName}");
    textWriter.WriteLine($"ApiId={output.ApiId}");
    textWriter.WriteLine($"ApiPath={output.ApiPath}");
    textWriter.WriteLine($"FunctionName={output.FunctionName}");
    textWriter.WriteLine($"WebAppName={output.WebAppName}");
}

await ValueTask.CompletedTask;

Environment.Exit(0);


