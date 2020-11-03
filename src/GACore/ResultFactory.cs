using GACore.Architecture;
using System;

namespace GACore
{
	public static class ResultFactory
	{
		public static IResult FromException(Exception ex) => Result.FromException(ex);

		public static IResult<T> FromException<T>(Exception ex) => Result<T>.FromException(ex);

		public static IResult FromSuccess() => Result.FromSuccess();

		public static IResult<T> FromSuccess<T>(T value) => Result<T>.FromSuccess(value); 

		public static IResult FromFailure(string failureReason) => Result.FromFailure(failureReason);

		public static IResult FromUnknownFailure() => Result.FromFailure();

		public static IResult FromFailure(Exception ex) => Result.FromException(ex);

		public static IResult<T> FromFailure<T>(string failureReason) => Result<T>.FromFailure(failureReason);

		public static IResult<T> FromUnknownFailure<T>() => Result<T>.FromFailure();

		public static IResult FromFailure(string format, object arg0)
			=> FromFailure(string.Format(format, arg0));

		public static IResult FromFailure(string format, params object[] args)
			=> FromFailure(string.Format(format, args));

		public static IResult<T> FromFailure<T>(string format, object arg0)
			=> FromFailure<T>(string.Format(format, arg0));

		public static IResult<T> FromFailure<T>(string format, params object[] args)
			=> FromFailure<T>(string.Format(format, args));

		public static IResult FromFailure<T>(Exception ex) => Result.FromException(ex);
	}
}