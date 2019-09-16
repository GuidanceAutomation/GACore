using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;

namespace GACore.Test
{
	[TestFixture]
	public class TGenericMailbox
	{
		[Test]
		public void InitNull()
		{
			Assert.Throws<ArgumentNullException>(() => new FooMailbox(1, null));
		}

		[Test]
		public void Equals()
		{
			HashSet<FooMailbox> mailboxes = new HashSet<FooMailbox>();

			FooMailbox fooMailbox = new FooMailbox(1, IPAddress.Loopback);

			Assert.IsTrue(mailboxes.Add(fooMailbox));
			Assert.IsFalse(mailboxes.Add(fooMailbox));

			IPAddress oneNineTwo = IPAddress.Parse("192.168.0.1");

			fooMailbox.Update(oneNineTwo);
			Assert.AreEqual(oneNineTwo, fooMailbox.Mail);

			Assert.IsFalse(mailboxes.Add(fooMailbox));
		}
	}
}
