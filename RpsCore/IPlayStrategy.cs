namespace RpsCore
{
    public interface IPlayStrategy
    {
        string Simbol { get; }
        bool Beat(IPlayStrategy strategy);
    }
}
