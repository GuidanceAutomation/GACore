﻿using GACore.Architecture;

namespace GACore
{
	public static class ResultFactory
	{
		public static IResult FromSuccess() => new Result(true, string.Empty);

		public static IGenericResult<T> FromSuccess<T>(T value) => new GenericResult<T>(true, value);

		public static IResult FromFailure(string failureReason) => new Result(false, failureReason);

		public static IResult FromUnknownFailure() => new Result(false, "Unknown");

		public static IGenericResult<T> FromFailure<T>(string failureReason) => new GenericResult<T>(false, default(T), failureReason);

		public static IGenericResult<T> FromUnknownFailure<T>() => new GenericResult<T>(false, default(T), "Unknown");

		public static IResult FromFailure(string format, object arg0)
			=> ResultFactory.FromFailure(string.Format(format, arg0));

		public static IResult FromFailure(string format, params object[] args)
			=> ResultFactory.FromFailure(string.Format(format, args));

		public static IGenericResult<T> FromFailure<T>(string format, object arg0)
			=> ResultFactory.FromFailure<T>(string.Format(format, arg0));

		public static IGenericResult<T> FromFailure<T>(string format, params object[] args)
			=> ResultFactory.FromFailure<T>(string.Format(format, args));
	}
}