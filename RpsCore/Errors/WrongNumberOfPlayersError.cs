using System;

namespace RpsCore.Erros
{
    public class WrongNumberOfPlayersError : Exception
    {
        public override string Message => "Number of players is wrong";
    }
}
