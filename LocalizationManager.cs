using Newtonsoft.Json;


namespace program
{
    public static class LocalizationManager
    {
        private static Dictionary<string, string> _strings = new Dictionary<string, string>();
        private static string _loadedLang = "";

        public static void LoadLanguage(string langCode)
        {

            if (_loadedLang == langCode && _strings.Count > 0)
            {
                return;
            }

            _strings = new Dictionary<string, string>();
            _loadedLang = langCode; 

            string baseDir = Application.StartupPath;
            string filePath = Path.Combine(baseDir, "Localization", $"{langCode}.json");

            try
            {
                if (!File.Exists(filePath))
                {
                    MessageBox.Show($"Файл локалізації не знайдено: {filePath}", "Критична помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                    return;
                }

                string json = File.ReadAllText(filePath);
                _strings = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при читанні файлу локалізації: {ex.Message}", "Критична помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        public static string GetString(string key)
        {
            if (_strings == null || !_strings.ContainsKey(key))
            {
                return $"[{key}_NOT_FOUND]";
            }
            return _strings[key];
        }
    }
}