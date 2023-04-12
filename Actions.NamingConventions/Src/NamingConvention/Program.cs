// See https://aka.ms/new-console-template for more information

using NamingConvention;

if (args.Length <= 0) throw new ArgumentException("Please supply arguments.");


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


Console.WriteLine($"::set-output name=ApimName::{environment}-{product}-Main-Apim-Weu");
Console.WriteLine($"::set-output name=ApiId::{type.Remove(4)}-{logic}");
Console.WriteLine($"::set-output name=ApiPath::{type.ToLower()}/{logic.ToLower()}");

Console.WriteLine($"::set-output name=FunctionName::{environment}-{product}-{type.Remove(4)}-{logic}-Func-001-Weu");



