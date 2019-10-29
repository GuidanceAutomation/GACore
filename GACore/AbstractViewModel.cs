using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GACore
{
	/// <summary>
	/// Boilerplate ViewModel for WPF applications
	/// </summary>
	public abstract class AbstractViewModel<T> : INotifyPropertyChanged where T : class
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
