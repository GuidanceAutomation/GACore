using GACore.Architecture;
using System;

namespace GACore
{
	public static class ResultFactory
	{
		public static IResult FromException(Exception ex) => new Result(ex);

		public static IResult<T> FromException<T>(Exception ex) => new Result<T>(ex);

		public static IResult FromSuccess() => new Result(true, string.Empty);

		public static IResult<T> FromSuccess<T>(T value) => new Result<T>(true, value);

		public static IResult FromFailure(string failureReason) => new Result(false, failureReason);

		public static IResult FromUnknownFailure() => new Result(false, "Unknown");

		public static IResult FromFailure(Exception ex)
		{
			if (ex == null) return FromUnknownFailure();

			return FromFailure(ex.Message);
		}

		public static IResult<T> FromFailure<T>(string failureReason) => new Result<T>(false, default(T), failureReason);

		public static IResult<T> FromUnknownFailure<T>() => new Result<T>(false, default(T), "Unknown");

		public static IResult FromFailure(string format, object arg0)
			=> FromFailure(string.Format(format, arg0));

		public static IResult FromFailure(string format, params object[] args)
			=> FromFailure(string.Format(format, args));

		public static IResult<T> FromFailure<T>(string format, object arg0)
			=> FromFailure<T>(string.Format(format, arg0));

		public static IResult<T> FromFailure<T>(string format, params object[] args)
			=> FromFailure<T>(string.Format(format, args));

		public static IResult FromFailure<T>(Exception ex)
		{
			if (ex == null) return FromUnknownFailure<T>();

			return FromFailure<T>(ex.Message);
		}
	}
}