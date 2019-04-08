namespace RpsCore
{
    public class Scissors : BasePlayStrategy
    {
        public override string Simbol { get => "S"; }
        public override bool Beat(IPlayStrategy strategy)
        {
            return strategy.Simbol == new Paper().Simbol;
        }
    }
}
