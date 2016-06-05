using System;
using System.IO;

namespace Legion_Addon_Repair_Tool
{
    class Program
    {
        public static int Count { get; private set; } = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the directory for your addons folder");
            string rootDir = Console.ReadLine();
            if (rootDir != null && Directory.Exists(rootDir))
            {
                DirectoryInfo root = new DirectoryInfo(rootDir);
                WalkDirectory(root);
                Console.WriteLine();
                Console.WriteLine("done: " + Count);
                Console.ReadKey();
            }
        }

        static void WalkDirectory(DirectoryInfo root)
        {
            var files = root.GetFiles("*.*");
            if (files != null)
            {
                foreach (FileInfo file in files)
                {
                    if (file.Extension.Contains("tga"))
                    {
                        File.Move(file.FullName, file.FullName.Replace(".tga", ".blp"));
                        Count++;
                        Console.Write(".");
                    }
                }
                var subDirs = root.GetDirectories();

                foreach (DirectoryInfo dir in subDirs)
                {
                    WalkDirectory(dir);
                }
            }
        }
    }
}