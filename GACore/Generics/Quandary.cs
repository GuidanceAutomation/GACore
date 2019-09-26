namespace GACore.Generics
{
	public class Quandary<T>
	{
		private T final;

		private T initial;

		/// <summary>
		/// Construct an instance of a quandary object, allowing the clear definition
		/// of an initial and final state in a system.
		/// </summary>
		/// <param name="initial">Instance of object defining the inital state.</param>
		/// <param name="final">Instance of object defining the final state.</param>
		public Quandary(T initial, T final)
		{
			this.initial = initial;
			this.final = final;
		}

		public T Final
		{
			get { return final; }
			set { this.final = value; }
		}

		public T Initial
		{
			get { return initial; }
			set { this.initial = value; }
		}
	}
}