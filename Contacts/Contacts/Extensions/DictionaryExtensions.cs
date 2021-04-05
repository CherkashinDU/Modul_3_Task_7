using System.Collections.Generic;

namespace Contacts.Extensions
{
    public static class DictionaryExtensions
    {
        public static TValue GetOrDefault<TKey, TValue>(
            this Dictionary<TKey, TValue> dic, TKey key, TValue defaultValue)
        {
            return dic.ContainsKey(key) ? dic[key] : defaultValue;
        }
    }
}
