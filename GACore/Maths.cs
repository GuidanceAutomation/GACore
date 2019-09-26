namespace GACore
{
	public class Maths
	{
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