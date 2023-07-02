using Newtonsoft.Json;
using static Framework.Models.DataModel;

namespace Framework.Utilities
{
    public class UserDataManager
    {
        public static List<UserData> userData = new();

        public static void ReadUserData()
        {
            using StreamReader jsonReader = new("Data\\user_data.json");
            string jsonContent = jsonReader.ReadToEnd();
            userData = JsonConvert.DeserializeObject<List<UserData>>(jsonContent);
        }
    }
}