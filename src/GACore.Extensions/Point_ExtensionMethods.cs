﻿using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System;

namespace GACore.Extensions
{
	public static class Point_ExtensionMethods
	{
		public static Rect ToBoundingBox(this IEnumerable<Point> points)
		{
			Rect rect = Rect.Empty;
			points.ToList().ForEach(e => rect.Union(e));

			return rect;
		}

		public static double GetLengthTo(this Point current, Point point) => current.GetVectorTo(point).Length;

		public static Point GetPointAt(this Point point, Vector vector) => new Point(point.X + vector.X, point.Y + vector.Y);

		public static Vector GetVectorTo(this Point current, Point point) => new Vector(point.X - current.X, point.Y - current.Y);

		public static bool IsNaN(this Point point) => double.IsNaN(point.X) || double.IsNaN(point.Y);

		public static Point Quantize(this Point point, double quantizeStep)
		{
			double x = point.X.Quantize(quantizeStep);
			double y = point.Y.Quantize(quantizeStep);

			return new Point(x,y);
		}
	}
}