using NUnit.Framework;
using System;
using System.Threading;
using GACore;
using GACore.NLog;
using NLog;

namespace GACore.Test
{
	[TestFixture]
	public class TViewModel
	{
		private AutoResetEvent propertyChangedSet = new AutoResetEvent(false);

		private TimeSpan timeout { get; } = TimeSpan.FromSeconds(5);

		[OneTimeSetUp]
		public void OneTimeSetUp()
		{
			GACore.NLog.NLogManager.Instance.LogLevel = LogLevel.Trace;
		}

		[Test]
		public void PropertyChanged()
		{
			FooModel fooModel = new FooModel();
			FooViewModel fooViewModel = new FooViewModel();
			fooViewModel.PropertyChanged += FooViewModel_PropertyChanged;

			Assert.IsNull(fooViewModel.Model);

			fooViewModel.Model = fooModel;

			Assert.IsTrue(propertyChangedSet.WaitOne(timeout));
			Assert.AreEqual(fooModel,fooViewModel.Model);

			fooViewModel.Model = null;

			Assert.IsTrue(propertyChangedSet.WaitOne(timeout));
			Assert.AreEqual(null, fooViewModel.Model);
		}

		private void FooViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			Assert.AreEqual("Model", e.PropertyName);
			propertyChangedSet.Set();
		}
	}
}
