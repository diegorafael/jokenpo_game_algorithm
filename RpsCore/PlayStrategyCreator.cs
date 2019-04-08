using RpsCore.Erros;
using System.Linq;

namespace RpsCore
{
    public static class PlayStrategyCreator
    {
        public static IPlayStrategy CreatePlayStrategy(string strategy)
        {
            IPlayStrategy result = null;

            ValidateStrategy(strategy);

            switch (strategy)
            {
                case "S":
                    result = new Scissors();
                    break;
                case "P":
                    result = new Paper();
                    break;
                case "R":
                    result = new Rock();
                    break;
            }

            return result;
        }

        private static void ValidateStrategy(string strategy)
        {
            if (new[] { "S", "P", "R" }.Contains(strategy) == false)
                throw new NoSuchStrategyError();
        }
    }
}
