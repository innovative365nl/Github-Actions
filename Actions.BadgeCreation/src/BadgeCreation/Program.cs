﻿using BadgeCreation;

if (args.Length <= 0) throw new ArgumentException("No arguments were provided.");

var path = args[0];
var file = Path.GetFileName(path);
var badgeName = args[1];
var badgeValue = Enum.TryParse(args[2], out StatusEnum status) ? status : StatusEnum.Pending;

if (!File.Exists(path: path)) throw new FileNotFoundException($"Cannot find file at path: {path}");

var badge = Badge.Create(badgeName, badgeValue);

Console.WriteLine($"Badge created with id: {badge.Id}");

File.WriteAllText(path, badge.ToString());