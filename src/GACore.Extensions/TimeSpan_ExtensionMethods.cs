﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace GACore.Extensions
{
	public static class TimeSpan_ExtensionMethods
	{
		/// <summary>
		/// Returns total duration of a sequence of timespans.
		/// </summary>
		public static TimeSpan Sum(this IEnumerable<TimeSpan> timespans) => timespans.Aggregate(TimeSpan.Zero, (result, value) => result.Add(value));
	}
}