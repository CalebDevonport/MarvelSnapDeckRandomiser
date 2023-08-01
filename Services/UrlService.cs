namespace MarvelSnapDeckRandomiser.Services
{
    public class UrlService : IUrlService
    {
        private const string UrlFilePath = "image-urls.txt";
        private readonly Dictionary<string, string> _cardUrlDict;

        public UrlService()
        {
            _cardUrlDict = ConvertTextFileToDictionary();
        }

        public Dictionary<string, string> GetCardUrlDict()
        {
            return _cardUrlDict;
        }

        private Dictionary<string, string> ConvertTextFileToDictionary()
        {
            Dictionary<string, string> d = new Dictionary<string, string>();

            using (var sr = new StreamReader(UrlFilePath))
            {
                string line = null;

                while ((line = sr.ReadLine()) != null)
                {
                    d.Add(line.Split('-')[0], line);
                }
            }
            return d;
        }
    }
}
