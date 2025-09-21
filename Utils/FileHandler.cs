using System.IO;
using Newtonsoft.Json;

namespace ProjetoCSharp.Utils
{
    public static class FileHandler
    {
        public static void SaveToTxt(string path, string content)
        {
            File.WriteAllText(path, content);
        }

        public static string ReadFromTxt(string path)
        {
            return File.Exists(path) ? File.ReadAllText(path) : "";
        }

        public static void SaveToJson<T>(string path, T data)
        {
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(path, json);
        }

        public static T ReadFromJson<T>(string path)
        {
            if (!File.Exists(path)) return default(T);
            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
