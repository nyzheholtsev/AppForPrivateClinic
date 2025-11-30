using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace program.Localization
{
    public static class LocalizationManager
    {
        private static Dictionary<string, object> _strings = new Dictionary<string, object>();
        private static string _loadedLang = "";

        public static string CurrentLanguage => _loadedLang;

        public static void LoadLanguage(string langCode)
        {
            if (_loadedLang == langCode && _strings.Count > 0) return;

            _strings = new Dictionary<string, object>();
            _loadedLang = langCode;

            string baseDir = Application.StartupPath;
            string filePath = Path.Combine(baseDir, "Localization", $"{langCode}.json");

            try
            {
                if (!File.Exists(filePath))
                {
                    return;
                }

                string json = File.ReadAllText(filePath);
                _strings = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка локалізації: {ex.Message}");
            }
        }

        public static string GetString(string key)
        {
            if (_strings == null || !_strings.ContainsKey(key))
                return $"[{key}]";

            return _strings[key].ToString();
        }

        public static string[] GetStringArray(string key)
        {
            if (_strings != null && _strings.ContainsKey(key))
            {
                object val = _strings[key];

                if (val is JArray jArray)
                {
                    return jArray.ToObject<string[]>();
                }
                if (val is string[] strArray)
                {
                    return strArray;
                }
            }
            return new string[0];
        }
    }
}