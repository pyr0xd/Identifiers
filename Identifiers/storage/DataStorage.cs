using Newtonsoft.Json;
using System.Xml;

public class JsonDataStorage : IDataStorage
{
    private const string FilePath = @"E:\\School02\\Identifiers";

    public void SaveInfoNames(InfoNames InfoNames)
    {
        var InfoNamess = new List<InfoNames>();
        if (File.Exists(FilePath))
        {
            string existingData = File.ReadAllText(FilePath);
            InfoNamess = JsonConvert.DeserializeObject<List<InfoNames>>(existingData) ?? new List<InfoNames>();
        }

        InfoNamess.Add(InfoNames);
        string jsonData = JsonConvert.SerializeObject(InfoNamess, Newtonsoft.Json.Formatting.Indented);
        try
        {
            File.WriteAllText(FilePath, jsonData);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}