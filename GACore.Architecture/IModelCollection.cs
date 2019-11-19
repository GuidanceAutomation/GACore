using System;
using System.Collections.Generic;

namespace GACore.Architecture
{
	public interface IModelCollection<T>
	{
		event Action<T> Added;

		event Action<T> Removed;

		IEnumerable<T> GetModels();
	}
}
