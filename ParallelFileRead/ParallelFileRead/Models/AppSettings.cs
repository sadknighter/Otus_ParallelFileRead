namespace ParallelFileRead.Models
{
    public class AppSettings
    {
        public string FilesFolder { get => _filesFolder; }

        public GenerationSettings GenerationSettings { get => _generationSettings; }

    private readonly string _filesFolder;
    private readonly GenerationSettings _generationSettings;

    public AppSettings(string filesFolder, GenerationSettings generationSettings)
    {
        _filesFolder = filesFolder;
        _generationSettings = generationSettings;
    }
}
}

