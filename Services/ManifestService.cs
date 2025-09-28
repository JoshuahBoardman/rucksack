namespace Rucksack.Services.Manifest
{
    using System.IO;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using Rucksack.Types;

    class ManifestService
    {
        private readonly string _manifestPath;
        public Manifest? Manifest { get; set; }

        public ManifestService(string manifestPath)
        {
            var manifestFileName = "manifest.json";
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

                this.Manifest = manifest;
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


