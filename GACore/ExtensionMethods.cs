using System.Collections.Generic;
using System.Windows.Media;

namespace GACore
{
    public static class ExtensionMethods
    {
        public static BrushCollection GetBrushCollection<T>(this Dictionary<T, BrushCollection> dictionary, T key)
        {
            if (dictionary.ContainsKey(key)) return dictionary[key];

            return new BrushCollection("Unknown", Brushes.Crimson, Brushes.White);
        }
    }
}