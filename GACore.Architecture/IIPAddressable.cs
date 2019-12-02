using System.Net;

namespace GACore.Architecture
{
	public interface IIPAddressable
	{
		IPAddress IPAddress { get; set; }
	}
}
