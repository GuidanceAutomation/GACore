using System;

namespace GACore
{
	public class Maths
	{
		private static readonly double radTol = (2 * Math.PI) / 180;

		/// <summary>
		/// Threshold for if two radian values are considered equal.
		/// </summary>
		public static double RadTol => radTol;

		/// <summary>
		/// True if two radian values are within threshold to be considered equal.
		/// </summary>
		public static bool AreWithinRadTol(double aRad, double bRad)
		{
			double headingDelta = Trigonometry.MinAngleRad(aRad, bRad);
			return headingDelta <= radTol;
		}

		/// <summary>
		/// Creates array of linearly spaced elements.
		/// </summary>
		public static double[] LinSpace(double x, double y, int n = 100)
		{
			if (n <= 0) return new double[0];
			else if (n == 1) return new double[1] { y };
			else
			{
				double[] linArray = new double[n];
				double stepSize = (y - x) / (double)(n - 1);

				for (int i = 0; i < n; i++)
				{
					linArray[i] = x + (i * stepSize);
				}

				linArray[0] = x;
				linArray[n - 1] = y;

				return linArray;
			}
		}
	}
}