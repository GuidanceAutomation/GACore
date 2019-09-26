using System;

namespace GACore.Extensions.Test.TestObjects
{
	public abstract class AbstractFoo
	{
		private readonly Guid guid;

		public AbstractFoo()
		{
			this.guid = Guid.NewGuid();
		}

		public Guid Guid => guid;

		public override int GetHashCode() => guid.GetHashCode();

		public abstract string ClassType { get; }

		public override bool Equals(object obj)
		{
			if (obj == null) return false;

			AbstractFoo other = (AbstractFoo)obj;

			if (other != null) return (guid == other.guid);

			return false;
		}
	}
}