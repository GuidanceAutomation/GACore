using GACore.Architecture;

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
	}
}
