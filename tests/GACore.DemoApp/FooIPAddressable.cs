using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using GACore.Architecture;

namespace GACore.DemoApp
{
	public class FooIPAddressable : IIPAddressable
	{
		public IPAddress IPAddress { get; set; } = IPAddress.Loopback;

		public void Randomize()
		{
			byte[] bytes = new byte[4];
			Tools.Random.NextBytes(bytes);

			IPAddress = new IPAddress(bytes);
		}
	}
}
