using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace GACore.Extensions
{
	public static class BitmapExtensions
	{
		/// <summary>
		/// Converts a bitmap to a generic sequence of bytes.
		/// </summary>
		/// <returns></returns>
		public static Stream ToStream(this Bitmap bitmap, ImageFormat imageFormat)
		{
			if (bitmap == null) throw new ArgumentNullException("bitmap");

			if (imageFormat == null) throw new ArgumentNullException("imageFormat");

			MemoryStream stream = new MemoryStream();
			bitmap.Save(stream, imageFormat);
			stream.Position = 0;
			return stream;
		}
	}
}