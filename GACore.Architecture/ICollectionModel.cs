using System;
using System.Collections.Generic;

namespace GACore.Architecture
{
	public interface ICollectionModel<T>
	{
		event Action<T> Added;

		event Action<T> Removed;

		IEnumerable<T> GetCollectionItems();
	}
}
