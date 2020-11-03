using System;

namespace GACore.Test
{
	public class FooModel
	{
		public Guid InstanceId { get; } = Guid.NewGuid();

		public FooModel()
		{
		}

		public override string ToString() => string.Format("FooModel InstanceId:{0}", InstanceId);
	}
}
