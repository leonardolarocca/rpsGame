using rockPaperScissor.Business;
using rockPaperScissor.Business.Interfaces;
using rockPaperScissor.Repository;
using rockPaperScissor.Repository.Interfaces;
using System;

namespace rockPaperScissor
{
    class Program
    {
        private static readonly IGameBusiness GameBusiness = new GameBusiness();
        private static readonly IGameRepository GameRepository = new GameRepository();

        static void Main(string[] args)
        {            
            Console.WriteLine(GameBusiness.RpsGameWinner(GameRepository.GetGame()));
            Console.ReadKey();

        }

        
    }
}
