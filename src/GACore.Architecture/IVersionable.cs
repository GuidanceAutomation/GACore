namespace GACore.Architecture
{
    public interface IVersionable
    {
        ISemVer Version { get; }
    }
}
