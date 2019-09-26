using System.Windows;

namespace GACore.Extensions
{
	public static class Rect_ExtensionMethods
	{
		public static Point ToCenterpoint(this Rect rect) => new Point(rect.Left + rect.Width / 2, rect.Top + rect.Height / 2);
	}
}