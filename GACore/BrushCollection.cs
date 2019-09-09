using System;
using System.Windows.Media;

namespace GACore
{
	/// <summary>
	/// Lightweight structure to tightly couple a foreground and background brush, and associated text.
	/// </summary>
	public struct BrushCollection
	{
		private readonly string text;

		private readonly Brush background;

		private readonly Brush foreground;

		public BrushCollection(string text, Brush foreground, Brush background)
		{
			if (string.IsNullOrEmpty(text)) throw new ArgumentOutOfRangeException("text");

			if (foreground == null) throw new ArgumentNullException("foreground");

			if (background == null) throw new ArgumentNullException("background");

			this.text = text;
			this.foreground = foreground;
			this.background = background;
		}

		public string ToBrushCollectionString() => string.Format("Text:{0} Foreground:{1} Background:{2}", Text, Foreground, Background);

		public override string ToString() => ToBrushCollectionString();

		public Brush Background => background;

		public Brush Foreground => foreground;

		public string Text => text;
	}
}