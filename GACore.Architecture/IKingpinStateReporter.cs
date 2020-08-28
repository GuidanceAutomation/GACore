using GAAPICommon.Architecture;

namespace GACore.Architecture
{
	public interface IKingpinStateReporter
	{
		IKingpinState KingpinState { get; }
	}
}