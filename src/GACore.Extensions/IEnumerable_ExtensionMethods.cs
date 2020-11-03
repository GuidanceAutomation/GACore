using System;
using System.Collections.Generic;
using System.Linq;

namespace GACore.Extensions
{
	public static class IEnumerable_ExtensionMethods
	{
		private static Random random = new Random(Guid.NewGuid().GetHashCode());

		internal static Random Random => random;

		/// <summary>
		/// Randomizes the contents of an IEnumerable
		/// </summary>
		public static IEnumerable<T> Randomize<T>(this IEnumerable<T> enumerable)
		{
			if (enumerable == null) return null;

			List<T> dataSet = new List<T>(enumerable);
			List<T> randomDataSet = new List<T>();

			for (int i = dataSet.Count; i > 0; i--)
			{
				int randomIndex = random.Next(0, i);
				randomDataSet.Add(dataSet[randomIndex]);
				dataSet.RemoveAt(randomIndex);
			}

			return randomDataSet;
		}

		/// <summary>
		/// Clones an IEnumerable<T> where T : ICloneable
		/// </summary>
		public static IEnumerable<T> Clone<T>(this IEnumerable<T> enumerableToClone) where T : ICloneable
			=> enumerableToClone.ToList().Select(e => (T)e.Clone()).ToList();
	}
}