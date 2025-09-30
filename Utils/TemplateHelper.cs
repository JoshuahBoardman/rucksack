
namespace Rucksack.Utils.Template
{
    public enum TemplateVariable
    {
        Package,
        Version
    }

    static class TemplateHelper
    {
        public static string Expand(string templateString, Dictionary<TemplateVariable, string> values)
        {
            foreach (var value in values)
            {
                string placeholder = "{" + value.Key.ToString().ToLower() + "}";
                templateString = templateString.Replace(placeholder, value.Value ?? string.Empty);
            }

            return templateString;
        }
    }
}
