namespace Rucksack.Utils.Path
{
    using System.IO;

    static class PathHelper
    {
        static public string ExpandPath(string path, string home)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("Path cannot be null");
            }

            if (path.StartsWith("~"))
            {
                return Path.GetFullPath(Path.Combine(home, path.Substring(1)));
            }
            else if (path.StartsWith("$HOME"))
            {
                return Path.GetFullPath(Path.Combine(home, path.Substring(5)));
            }

            return Path.GetFullPath(path);
        }

        public static bool IsSymlink(string path)
        {
            var info = new FileInfo(path);
            return info.Exists && info.LinkTarget != null;
        }

        // Check if the file already exists
        static public bool FileExists(string targetPath)
        {
            return File.Exists(targetPath) || Directory.Exists(targetPath);
        }

        //TODO: Refacotr this to be more robust
        // Checks if the target path symlinks to the source file
        static public bool LinksTo(string targetPath, string source)
        {
            if (File.Exists(targetPath))
            {
                var fileInfo = new FileInfo(targetPath);
                return fileInfo.LinkTarget == source;
            }

            if (Directory.Exists(targetPath))
            {
                var dirInfo = new DirectoryInfo(targetPath);
                return dirInfo.LinkTarget == source;
            }

            return false;
        }
    }
}
