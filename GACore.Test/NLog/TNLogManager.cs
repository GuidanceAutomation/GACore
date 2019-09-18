using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GACore.NLog;
using NUnit.Framework;
using System.IO;
using NLog;

namespace GACore.Test.NLog
{
	[TestFixture]
	public class TNLogManager
	{
		[Test]
		public void GetFileTargetLogger()
		{
			NLogManager manager = NLogManager.Instance;

			manager.LogDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());

			Logger logger = manager.GetFileTargetLogger("TNLogManager_GetFileTargetLogger");

			logger.WriteValidateLoglevels();
			logger.StartFilePathLoggerProcess();

			Assert.IsTrue(File.Exists(logger.GetFilePath()));
		}
	}
}
