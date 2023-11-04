namespace ParallelFileRead.Models
{
    public class GenerationSettings
    {
        public bool Enabled { get => _enabled; }
        public int FilesCount { get => _filesCount; }

        private readonly bool _enabled;
        private readonly int _filesCount;

        public GenerationSettings(bool enabled, int filesCount)
        {
            _enabled = enabled;
            _filesCount = filesCount;
        }
    }
}
