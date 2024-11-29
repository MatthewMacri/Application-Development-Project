using System;
using System.Globalization;

public static class LanguageManager
{
    public static event Action LanguageChanged;

    private static CultureInfo _currentCulture = new CultureInfo("en-US");
    public static CultureInfo CurrentCulture
    {
        get => _currentCulture;
        set
        {
            if (_currentCulture != value)
            {
                _currentCulture = value;
                LanguageChanged?.Invoke();
            }
        }
    }
}