using GACore.Architecture;
using NLog;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GACore
{
	/// <summary>
	/// Boilerplate ViewModel for WPF applications
	/// </summary>
	public abstract class AbstractViewModel<T> : IViewModel<T> where T : class
	{
		private T model = null;

		public T Model
		{
			get { return model; }
			set
			{
				model = value;
				HandleModelUpdate();
			}
		}

		public Logger Logger { get; } = NLog.NLogManager.Instance.GetFileTargetLogger("ViewModel");

		protected virtual void HandleModelUpdate()
		{
		}

		public AbstractViewModel()
		{
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnNotifyPropertyChanged([CallerMemberName] String propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
