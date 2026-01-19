using System.Collections.Generic;

namespace BadPracticeProject.Data
{
    public static class FakeCache
    {
        public static Dictionary<string, string> Cache = new Dictionary<string, string>();

        public static void Set(string key, string value)
        {
            // No locking → race condition
            Cache[key] = value;
        }

        public static string Get(string key)
        {
            if (Cache.ContainsKey(key))
                return Cache[key];

            return null;
        }
    }
}
