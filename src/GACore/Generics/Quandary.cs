namespace GACore.Generics
{
	public class Quandary<T>
	{
		public Quandary()
			: this(default, default)
		{
		}

		/// <summary>
		/// Construct an instance of a quandary object, allowing the clear definition
		/// of an initial and final state in a system.
		/// </summary>
		/// <param name="initial">Instance of object defining the inital state.</param>
		/// <param name="final">Instance of object defining the final state.</param>
		public Quandary(T initial, T final)
		{
			Initial = initial;
			Final = final;
		}

		public T Final { get; set; }

		public T Initial { get; set; }
	}
}