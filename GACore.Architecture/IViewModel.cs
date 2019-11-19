using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GACore.Architecture
{
	public interface IViewModel<T> : INotifyPropertyChanged where T: class
	{
		T Model { get; }
	}
}
