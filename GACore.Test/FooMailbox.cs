using System.Net;

namespace GACore.Test
{
	/// <summary>
	/// Dev class for testing generic mailbox functionality.
	/// </summary>
	internal class FooMailbox : GenericMailbox<int, IPAddress>
	{
		public FooMailbox(int id, IPAddress current)
			: base(id, current)
		{
		}
	}
}