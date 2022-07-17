namespace BenchmarkDemo
{
    public class DictionaryLookup
    {
        readonly Dictionary<string, string> _myDictionary;

        public DictionaryLookup()
        {
            _myDictionary = new();

            for (int i = 0; i < 100; i++)
            {
                _myDictionary[i.ToString()] = $"test_{i}";
            }
        }

        public string? GetValueByKey(string key)
        {
            if (_myDictionary.ContainsKey(key))
            {
                return _myDictionary[key];
            }

            return null;
        }

        public string GetValueByKeyWithLinq(string key)
        {
            return _myDictionary.FirstOrDefault(a => a.Key == key).Value;
        }

        public string? GetValueByKeyWithTryGet(string key)
        {
            _myDictionary.TryGetValue(key, out string? value);

            return value;
        }

        public string? GetValueByKeyManual(string key)
        {
            foreach (KeyValuePair<string, string> item in _myDictionary)
            {
                if (item.Key == key)
                {
                    return item.Value;
                }
            }

            return null;
        }
    }
}
