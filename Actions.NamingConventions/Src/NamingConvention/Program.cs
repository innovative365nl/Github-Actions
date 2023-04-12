// See https://aka.ms/new-console-template for more information

if (args.Length <= 0) throw new ArgumentException("Please supply arguments.");


const string path             = "unknown";
const string argumentErrorStr = "Please supply arguemnt: `{0}` to action.";


var folderName = args[0];
if (string.IsNullOrEmpty(folderName) || folderName.Equals(path))
    throw new ArgumentException(string.Format(argumentErrorStr, path));

var environment = args[1];
environment = environment.Remove(1);
var product = args[2];
var logic   = string.Empty;

product = product.Remove(8);

    
var type = folderName.Split(".")[0];
logic = folderName.Split(".")[1];

if (type.Equals("unknown"))
    throw new ArgumentException(string.Format(argumentErrorStr, type));

else if (type.ToLower().Equals("orchestrators"))
{
    type = "Orch";
}
Console.WriteLine($"::set-output name=ApimName::{environment}-{product}-Main-Apim-Weu");
Console.WriteLine($"::set-output name=ApiId::{type.Remove(4)}-{logic}");
Console.WriteLine($"::set-output name=ApiPath::{type.ToLower()}/{logic.ToLower()}");

Console.WriteLine($"::set-output name=FunctionName::{environment}-{product}-{type.Remove(4)}-{logic}-Func-001-Weu");



