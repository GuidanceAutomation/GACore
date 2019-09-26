using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GACore.Extensions
{
	public static class Byte_ExtensionMethods
	{
		public static bool IsCurrentByteTickLarger(this byte current, byte other)
			=> (current < other && (other - current) > 128) || (current > other && (current - other) < 128);

		public static string ToBitString(this byte value) => Convert.ToString(value, 2).PadLeft(8, '0');

		public static string ToHexString(this byte[] bytes)
		{
			if (bytes == null) return string.Empty;

			StringBuilder builder = new StringBuilder();

			bytes.ForEach(e => builder.AppendFormat(" {0}", e.ToHexString()));

			return builder.ToString();
		}

		public static string ToHexString(this byte value) => string.Format("{0:x2}", value);

		public static byte ToHighNybble(this byte value) => (byte)(value & 0x0F);

		public static byte ToLowNybble(this byte value) => (byte)((value & 0xFF) >> 4);
	}
}
