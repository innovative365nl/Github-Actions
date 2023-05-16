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

var github = new GitHubClient(new ProductHeaderValue("ReadmeBadges"));
github.Credentials = new Credentials(token);

// var repo = await github.Repository.Get(owner: "innovative365nl",name: ".github-private");
var repos = await github.Repository.GetAllForOrg("innovative365nl");
if (repo != null)
    Console.WriteLine($"Repository found: {repo.FullName}");
Console.WriteLine($"Repositories found: {repos.Count}");
foreach (Repository repository in repos)
{
    Console.WriteLine($"Repository found: {repository.FullName}");
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