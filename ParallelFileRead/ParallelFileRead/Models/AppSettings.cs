
namespace ParallelFileRead.Models
{
    public class AppSettings
    {
        public string FilesFolder { get => _filesFolder; }

        public char SymbolForCounting { get => _symbolForCounting; }

        public GenerationSettings GenerationSettings { get => _generationSettings; }

        private string _filesFolder;
        private readonly GenerationSettings _generationSettings;
        private char _symbolForCounting;

        public AppSettings(string filesFolder, char symbolForCounting, GenerationSettings generationSettings)
        {
            _filesFolder = filesFolder;
            _generationSettings = generationSettings;
            _symbolForCounting = symbolForCounting;
        }

        public void ChangeFilesFolder(string filesFolder)
        {
            this._filesFolder = filesFolder;
        }

        public void ChangeSymbolForCounting(char symbolForCounting)
        {
            this._symbolForCounting = symbolForCounting;
        }
    }
}

