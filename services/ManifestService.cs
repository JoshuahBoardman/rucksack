using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Rucksack.Types;

namespace Rucksack.Services.Manifest
{

    //TODO: Think about swapping DotFiles and Packages to dictionaries.
    class Manifest
    {
        public List<DotFile> DotFiles { set; get; } = new();
        public List<Package> Packages { set; get; } = new();
        public Dictionary<string, PackageManager> PackageManagers { set; get; } = new();
    }

    // NOTE: Could make the ManifestService into a generic FileService which can work on any files

    //TODO: WIll likely need to make this a singleton and pass it in as DI
    class ManifestService
    {
        private readonly string _manifestPath;

        public ManifestService(string manifestPath)
        {
            var manifestFileName = "manifest.json"; //TODO: Cehck if they inlucde the `/` at the end of the path
            _manifestPath = $"{manifestPath}/{manifestFileName}";
        }

        public void Load()
        {
            try
            {
                string rawManifestText = File.ReadAllText(this._manifestPath);

                var jsonOptions = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                };

                var manifest = JsonSerializer.Deserialize<Manifest>(rawManifestText, jsonOptions);

                if (manifest == null)
                {
                    Console.Error.WriteLine("Manifest is null");
                    return;
                }

                if (manifest.DotFiles == null || manifest.DotFiles.Count == 0)
                {
                    Console.Error.WriteLine("No dotFiles provided");
                    return;
                }

                Console.WriteLine("Linking these packages");


                foreach (DotFile dotFile in manifest.DotFiles)
                {
                    Console.WriteLine(dotFile.Name);
                }
            }

            catch (Exception ex)
            {
                Console.Error.WriteLine(
                    $"Error: Could not read manifest file at '{this._manifestPath}'. \n Reason: {ex.Message}"
                );

            }

        }

    }

}


