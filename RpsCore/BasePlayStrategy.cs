namespace RpsCore
{
    public abstract class BasePlayStrategy : IPlayStrategy
    {
        internal BasePlayStrategy() { }

        public abstract string Simbol { get; }
        public abstract bool Beat(IPlayStrategy strategy);

        public override bool Equals(object obj)
        {
            return Simbol == ((IPlayStrategy)obj).Simbol;
        }
    }
}
