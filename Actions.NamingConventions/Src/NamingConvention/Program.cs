// See https://aka.ms/new-console-template for more information

if (args.Length <= 0) throw new ArgumentException("Please supply arguments.");


const string path             = "unknown";
const string argumentErrorStr = "Please supply arguemnt: `{0}` to action.";



var param = args[1];
if (string.IsNullOrEmpty(param) || param.Equals(path))
    throw new ArgumentException(string.Format(argumentErrorStr, path));

var environment = args[3];
environment = environment.Remove(1);
var product = args[5];
var logic   = string.Empty;

product = product.Remove(8);

    
var type = param.Split(".")[0];
logic = param.Split(".")[1];

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



