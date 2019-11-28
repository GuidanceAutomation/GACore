using GACore.Architecture;
using GACore.NLog;
using NLog;
using System;
using System.ComponentModel;
using System.Windows;
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
				T oldValue = model;
				model = value;
				HandleModelUpdate(oldValue, model);
				OnNotifyPropertyChanged();
			}
		}
			
		public Logger Logger { get; } = LoggerFactory.GetStandardLogger(StandardLogger.ViewModel);

		protected virtual void HandleModelUpdate(T oldValue, T newValue)
		{
			Logger.Trace("[{0}] HandleModelUpdate() oldValue: {1}, newValue: {2}",
				GetType().Name, 
				oldValue == null? "null" : oldValue.ToString(),
				newValue == null ? "null" : newValue.ToString());
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
