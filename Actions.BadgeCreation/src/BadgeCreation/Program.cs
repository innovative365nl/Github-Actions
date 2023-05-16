using System.Text;
using BadgeCreation;
using Octokit;

if (args.Length <= 0) throw new ArgumentException("No arguments were provided.");

var path = args[0];
var file = Path.GetFileName(path);
var badgeName = args[1];
var badgeValue = Enum.TryParse(args[2], out StatusEnum status) ? status : StatusEnum.Pending;
var badgeColor = args[3];
var badgeColumn = args[4];
var token = args[5];

var gitHubClient = new GitHubClient(new ProductHeaderValue("ReadmeBadges"));
gitHubClient.Credentials = new Credentials(token);

var repo = await gitHubClient.Repository.Get(owner: "innovative365nl",name: ".github-private");
if (repo != null)
    Console.WriteLine($"Repository found: {repo.FullName}");

var readme = await gitHubClient.Repository.Content.GetAllContentsByRef(owner: "innovative365nl", name: ".github-private", path: "profile/README.md", reference: "main");

var targetFile = readme.FirstOrDefault(x => x.Name == "README.md");
if (targetFile != null)
    Console.WriteLine($"Target file found: {targetFile.Name}");

if (targetFile.EncodedContent != null)
{
    var decodedContent = Encoding.UTF8.GetString(Convert.FromBase64String(targetFile.EncodedContent));
    Console.WriteLine($"Decoded content: {decodedContent}");
}

if (!File.Exists(path: path)) throw new FileNotFoundException($"Cannot find file at path: {path}");

var badge = new Badge(name: badgeName, status: badgeValue, color: badgeColor);

Console.WriteLine($"Badge created with id: {badge.Id}");

var markdownBadge = GetMarkdownBadge(badge: badge);

File.WriteAllText(path, markdownBadge);


string GetMarkdownBadge(Badge badge)
{
    var badgeUri = $"https://img.shields.io/badge/{badge.Name}-{badge.Status.ToString()}-{badge.Color}";
    var markdownBadge = $"![{badge.Name}]({badgeUri})";

    return markdownBadge;
}