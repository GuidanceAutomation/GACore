using GACore.Architecture;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GACore.DemoApp
{
	public class FooKingpin : IKingpinStateReporter
	{

		public IKingpinState KingpinState { get; private set; } = new FooKingpinState();

		public void Randomize()
		{
			KingpinState = new FooKingpinState();
		}

		public void SetGood()
		{
			KingpinState = FooKingpinState.FromGood();
		}

		public FooKingpin()
		{
		}
	}
}