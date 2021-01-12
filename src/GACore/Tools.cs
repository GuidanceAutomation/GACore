using System;
using System.Text.RegularExpressions;
using GAAPICommon.Architecture;
using Microsoft.Win32;

namespace GACore
{
	public static class Tools
	{
		public static Random Random { get; } = new Random();

		private static Regex versionRegex { get; } = new Regex(@"(?<major>\d+)(?:.)(?<minor>\d+)(?:.)(?<patch>\d+)(?:.)(?<releaseFlag>\d)");

		public static SemVer ParseVersionString(string value)
        {
			if (string.IsNullOrEmpty(value))
				return null;

			Match match = versionRegex.Match(value);

			if (match.Success)
			{
				int major = int.Parse(match.Groups["major"].Value);
				int minor = int.Parse(match.Groups["minor"].Value);
				int patch = int.Parse(match.Groups["patch"].Value);
				ReleaseFlag releaseFlag = (ReleaseFlag)int.Parse(match.Groups["releaseFlag"].Value);

				return new SemVer(major, minor, patch, releaseFlag);
			}

			return null;
		}

		public static FleetManagementMetadata GetInstalledFleetManagementMetadata()
        {
			try
            {
				RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);

				if (baseKey == null)
					return null;

				RegistryKey fmKey = baseKey.OpenSubKey(@"SOFTWARE\GuidanceAutomation\Fleet Management");

				if (fmKey == null)
					return null;

				string productName = (string) fmKey.GetValue("ProductName", null);
				string versionString = (string) fmKey.GetValue("Version", null);

				SemVer semVer = Tools.ParseVersionString(versionString);

				return new FleetManagementMetadata(productName, semVer);
			}
			catch
            {			
				return null;
            }
        }

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