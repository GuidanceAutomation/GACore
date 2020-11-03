using System;

namespace GACore
{
	public static class Tools
	{
		public static Random Random { get; } = new Random();

		public static T RandomEnumValue<T>() where T : Enum
		{
			var values = Enum.GetValues(typeof(T));
			return (T)values.GetValue(Random.Next(values.Length));
		}

		public static string GetTempFilenameWithExtension(string extension = ".xxx")
		{
			if (string.IsNullOrEmpty(extension)) throw new ArgumentNullException("extension");

			return System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + extension;
		}
	}
}