using GACore.Architecture;
using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("GACore.Test")]
namespace GACore
{
	public class Result : IResult
	{	
		internal Result(Exception ex)
			: this(false,  ex.Message ?? throw new ArgumentNullException("ex"))
		{
		}

		internal Result(bool isSuccessful, string failureReason = default)
		{
			if (isSuccessful && !string.IsNullOrEmpty(failureReason)) throw new ArgumentOutOfRangeException("Can't be successful and include a failure reason");

			if (isSuccessful == false && string.IsNullOrEmpty(failureReason)) failureReason = "Unknown";

			IsSuccessful = isSuccessful;
			FailureReason = failureReason ?? string.Empty;
		}

		public string FailureReason { get; } = string.Empty;

		public bool IsSuccessful { get; } = false;

		public virtual string ToResultString() => IsSuccessful ? "Success"
					: string.Format("Failed: {0}", FailureReason);

		public override string ToString() => ToResultString();
	}

	public class Result<T> : Result, IResult<T>
	{
		internal Result(Exception ex)
			: this(false, default, ex.Message ?? throw new ArgumentNullException("ex"))
		{
		}

		internal Result(bool isSuccessful, T value = default, string failureReason = default)
			: base(isSuccessful, failureReason)
		{
			if (isSuccessful && value == null) throw new ArgumentOutOfRangeException("Can't be successful and return a null value");

			Value = isSuccessful ? value : default;
		}

		public T Value { get; }

		public override string ToResultString() => IsSuccessful ? string.Format("Success: {0}", Value)
			: string.Format("Failed: {0}", FailureReason);
	}
}