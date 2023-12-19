

using Newtonsoft.Json;

namespace ContactApp.Storage
{
    public class JsonInfoNamesStorage : InfoNamesStorage
    {
        private readonly string _filePath;(@"E:\\School02\\Identifiers\names.csv")

        public JsonInfoNamesStorage(string filePath)
        {
            _filePath = filePath;
        }

        public List<InfoNames> LäsInfoNameser()
        {
            if (!File.Exists(_filePath))
            {
                return new List<InfoNames>();
            }

            string json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<InfoNames>>(json);
        }

        public void SparaInfoNameser(List<InfoNames> InfoNameser)
        {
            string json = JsonSerializer.Serialize(InfoNameser);
            File.WriteAllText(_filePath, json);
        }

        public object LäsInfoNames()
        {
            throw new NotImplementedException();
        }

        public void SparaInfoNames(object infoNames)
        {
            throw new NotImplementedException();
        }
    }
}