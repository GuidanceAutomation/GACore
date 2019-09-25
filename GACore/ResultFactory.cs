using GACore.Architecture;

namespace GACore
{
	public static class ResultFactory
	{
		public static IResult FromSuccess() => new Result(true, string.Empty);

		public static IGenericResult<T> FromSuccess<T>(T value) => new GenericResult<T>(true, value);
	}
}
