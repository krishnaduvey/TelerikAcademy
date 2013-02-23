﻿using System;
using System.IO;
using System.Text.RegularExpressions;

static class PathStorage
{
    private const string defaultFile = "../../input.txt";

    public static Path Load(string file = defaultFile)
    {
        Path path = new Path();

        foreach (string line in File.ReadAllLines(file))
        {
            foreach (Match item in Regex.Matches(line, @"X: (\d+), Y: (\d+), Z: (\d+)"))
            {
                int x = int.Parse(item.Groups[1].Value);
                int y = int.Parse(item.Groups[2].Value);
                int z = int.Parse(item.Groups[3].Value);

                path.Add(new Point3D(x, y, z));
            }
        }

        return path;
    }

    public static void Write(Path path, string file = defaultFile)
    {
        File.WriteAllText(file, path.ToString());
    }
}
