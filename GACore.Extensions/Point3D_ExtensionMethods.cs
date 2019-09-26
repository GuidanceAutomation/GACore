using System.Windows.Media.Media3D;

namespace GACore.Extensions
{
	public static class Point3D_ExtensionMethods
	{
		public static double GetLengthTo(this Point3D current, Point3D point) => current.GetVector3DTo(point).Length;

		public static Point3D Add(this Point3D point3D, Vector3D vector)
			=> new Point3D(point3D.X + vector.X, point3D.Y + vector.Y, point3D.Z + vector.Z);

		public static Point3D GetPoint3DAt(this Point3D point, Vector3D vector)
			=> new Point3D(point.X + vector.X, point.Y + vector.Y, point.Z + vector.Z);

		public static bool IsNaN(this Point3D point)
			=> double.IsNaN(point.X) || double.IsNaN(point.Y) || double.IsNaN(point.Z);

		public static Vector3D GetVector3DTo(this Point3D current, Point3D point)
			=> new Vector3D(point.X - current.X, point.Y - current.Y, point.Z - current.Z);
	}
}
