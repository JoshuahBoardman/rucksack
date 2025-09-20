using Rucksack.Types;

namespace Rucksack.Services.DotFiles
{
    class DotFilesService
    {
        public List<DotFile> DotFiles { get; set; } = new();

        public DotFilesService(List<DotFile> dotFiles)
        {
            this.DotFiles = dotFiles;
        }
    }
}
