using Newtonsoft.Json;
using static Framework.Models.DataModel;

namespace Framework.Utilities
{
    public class ConfigDataManager
    {
        public static List<ConfigData> configData = new();

        public static void ReadConfigData()
        {
            using StreamReader jsonReader = new("Data\\config_data.json");
            string jsonContent = jsonReader.ReadToEnd();
            configData = JsonConvert.DeserializeObject<List<ConfigData>>(jsonContent);
        }
    }
}