public static class LanguageManager
{
    public static event Action LanguageChanged;
    private static System.Globalization.CultureInfo _currentCulture = new System.Globalization.CultureInfo("en-US");

    public static System.Globalization.CultureInfo CurrentCulture
    {
        get => _currentCulture;
        set
        {
            if (_currentCulture != value)
            {
                _currentCulture = value;
                LanguageChanged?.Invoke(); // Notify all listeners
            }
        }
    }
}