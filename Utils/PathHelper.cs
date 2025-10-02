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
    }
}
