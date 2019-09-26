using System;

namespace GACore.Generics
{
	public class Limit<T> where T : IComparable
	{
		private readonly object lockObject = new object();

		private T maximum;

		private T minimum;

		/// <summary>
		/// Limit object, allowing clear definition of the minimum and maximum.
		/// </summary>
		/// <param name="min">instance of object defining the minimum limit.</param>
		/// <param name="max">instance of object defining the maximum limit.</param>
		public Limit(T minimum, T maximum)
		{
			SanityCheck(minimum, maximum);

			this.minimum = minimum;
			this.maximum = maximum;
		}

		public T Maximum
		{
			get { return maximum; }
			set
			{
				lock (lockObject)
				{
					SanityCheck(minimum, value);
					this.maximum = value;
				}
			}
		}

		public T Minimum
		{
			get { return minimum; }
			set
			{
				lock (lockObject)
				{
					SanityCheck(value, maximum);
					this.minimum = value;
				}
			}
		}

		private void SanityCheck(T minimum, T maximum)
		{
			if (minimum.CompareTo(maximum) > 0) throw new ArgumentOutOfRangeException("Minimum value cannot be greater than maximum value.");
		}
	}
}