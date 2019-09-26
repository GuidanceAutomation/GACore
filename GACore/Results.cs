using GACore.Architecture;
using System;

namespace GACore
{
	public class Result : IResult
	{
		private readonly string failureReason;

		private readonly bool isSuccessful;

		public Result(bool isSuccessful, string failureReason = default(string))
		{
			if (isSuccessful && !string.IsNullOrEmpty(failureReason)) throw new ArgumentOutOfRangeException("Can't be succesful and include a failure reason");

			if (isSuccessful == false && string.IsNullOrEmpty(failureReason)) failureReason = "Unknown";

			this.isSuccessful = isSuccessful;
			this.failureReason = failureReason ?? string.Empty;
		}

		public string FailureReason => failureReason;

		public bool IsSuccessful => isSuccessful;

		public virtual string ToResultString() => IsSuccessful ? "Success"
					: string.Format("Failed: {0}", FailureReason);

		public override string ToString() => ToResultString();
	}

	public class GenericResult<T> : Result, IGenericResult<T>
	{
		private readonly T value;

		public GenericResult(bool isSuccessful, T value = default(T), string failureReason = default(string))
			: base(isSuccessful, failureReason)
		{
			if (isSuccessful && value == null) throw new ArgumentOutOfRangeException("Can't be succesful and return a null value");

			this.value = isSuccessful ? value : default(T);
		}

		public T Value => value;

		public override string ToResultString() => IsSuccessful ? string.Format("Success: {0}", Value)
			: string.Format("Failed: {0}", FailureReason);
	}
}