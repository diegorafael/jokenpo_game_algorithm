namespace RpsCore
{
    public class Paper : BasePlayStrategy
    {
        public override string Simbol { get => "P"; }
        public override bool Beat(IPlayStrategy strategy)
        {
            return strategy.Simbol == new Rock().Simbol;
        }
    }
}
