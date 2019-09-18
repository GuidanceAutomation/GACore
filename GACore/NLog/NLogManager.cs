using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace GACore.NLog
{
	/// <summary>
	/// Singleton wrapper around NLog to manage loggers.
	/// </summary>
	public class NLogManager : INotifyPropertyChanged
	{
		private static NLogManager instance = new NLogManager();

		public event PropertyChangedEventHandler PropertyChanged;

		private string logDir = Path.Combine(new string[] { Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"Guidance Automation", @"Logs" });

		public string LogDir
		{
			get { return logDir; }
		
			set
			{
				if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("logDir");

				if (logDir != value)
				{
					logDir = value;
					OnNotifyPropertyChanged();
				}
			}
		}

		public static NLogManager Instance => instance;

		private readonly object lockObject = new object();

		public NLogManager()
		{
		}

		public IEnumerable<Logger> GetLoggers()
		{
			List<Logger> loggers = new List<Logger>();

			if (LogManager.Configuration != null)
			{
				foreach (Target target in LogManager.Configuration.AllTargets.ToList())
				{
					loggers.Add(LogManager.GetLogger(target.Name));
				}
			}

			return loggers;
		}

		private LogLevel logLevel = LogLevel.Info;

		public LogLevel LogLevel
		{
			get { return logLevel; }

			set
			{
				lock (lockObject)
				{
					if (logLevel != value)
					{
						logLevel = value;

						if (LogManager.Configuration == null) HandleNullConfiguration();

						foreach (LoggingRule rule in LogManager.Configuration.LoggingRules)
						{
							rule.SetLoggingLevels(logLevel, LogLevel.Fatal);
						}

						LogManager.ReconfigExistingLoggers();
						OnNotifyPropertyChanged();
					}
				}
			}
		}

		public Logger GetFileTargetLogger(string name)
		{
			lock (lockObject)
			{
				if (LogManager.Configuration == null) HandleNullConfiguration();

				name = name.ToLowerInvariant();
				Logger existing = GetLoggers().FirstOrDefault(e => e.Name == name);

				if (existing != null) return existing;

				string fileName = Path.Combine(new[] { LogDir, name + ".log" });

				FileInfo info = new FileInfo(fileName);

				if (!info.Directory.Exists) Directory.CreateDirectory(info.Directory.FullName);

				FileTarget target = TargetFactory.GetDefaultFileTarget(name, fileName);

				LoggingRule rule = new LoggingRule(name, LogLevel, target);
				LogManager.Configuration.LoggingRules.Add(rule);
				LogManager.Configuration.AddTarget(target);

				LogManager.ReconfigExistingLoggers();

				return GetLoggers().FirstOrDefault(e => e.Name == name);
			}
		}

		private void HandleNullConfiguration()
		{
			LogManager.Configuration = new LoggingConfiguration();
			Directory.CreateDirectory(LogDir);
		}

		protected void OnNotifyPropertyChanged([CallerMemberName] String propertyName = "")
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
