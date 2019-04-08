using System;

namespace RpsCore.Erros
{
    public class NoSuchStrategyError : Exception
    {
        public override string Message => "Unknown Strategy";
    }
}
