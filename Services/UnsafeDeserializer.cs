using Newtonsoft.Json;

namespace BadPracticeProject.Services
{
    public class UnsafeDeserializer
    {
        public T Deserialize<T>(string json)
        {
            // No validation, no settings → unsafe
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
