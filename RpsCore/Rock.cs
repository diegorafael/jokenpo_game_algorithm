namespace RpsCore
{
    public class Rock : BasePlayStrategy
    {
        public override string Simbol { get => "R"; }

        public override bool Beat(IPlayStrategy strategy)
        {
            return strategy.Simbol == new Scissors().Simbol;
        }
    }
}
