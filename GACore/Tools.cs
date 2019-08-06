using System;

namespace GACore
{
    public static class Tools
    {
        private static Random random = new Random();

        public static Random Random => random;

        public static T RandomEnumValue<T>() where T : Enum
        {
            var values = Enum.GetValues(typeof(T));
            return (T)values.GetValue(Random.Next(values.Length));
        }
    }
}