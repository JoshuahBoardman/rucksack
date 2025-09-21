
namespace Rucksack.Utils.Path
{
    static class PathHelper
    {
        static public string ExpandPath(string path)
        {
            string expandedPath = "";

            if (path.StartsWith('~'))
            {
                string home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                expandedPath = $"{home}{path.Substring(1)}";
            }
            else
            {
                expandedPath = path;
            }

            return expandedPath;
        }
    }
}
