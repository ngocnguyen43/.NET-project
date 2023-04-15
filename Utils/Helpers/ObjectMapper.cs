using Newtonsoft.Json;
namespace WebAPI.Utils.Helpers
{
    public class ObjectMapper
    {
        private string json;
        public static T? ToModel<T>(string json) => JsonConvert.DeserializeObject<T>(value: json);
        public static string? ToString<T>(T obj) { return null; }
    }
}
