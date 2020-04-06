namespace GACore.Architecture
{
	/// <summary>
	/// Lightweight structure to return a failure reason when an operation fails for traceability.
	/// </summary>
	public interface IResult
	{
		string FailureReason { get; }

		bool IsSuccessful { get; }
	}

	/// <summary>
	/// Expands IResult to include a result object
	/// </summary>
	/// <typeparam name="T">Default(T) if unsuccessful, cannot be null if successful.</typeparam>
	public interface IResult<T> : IResult
	{
		T Value { get; }
	}
}