using System;
using System.Collections.Generic;

namespace GACore.Architecture
{
	public interface IKeyedEnumerable<T>
	{
		Guid Key { get; }

		IEnumerable<T> Items { get; }
	}
}
