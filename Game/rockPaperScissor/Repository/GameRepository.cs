using rockPaperScissor.Dto;
using rockPaperScissor.Repository.Interfaces;
using System.Collections.Generic;

namespace rockPaperScissor.Repository
{
    public class GameRepository : IGameRepository
    {
        public GameDto GetGame()
        {
            var Game = new GameDto();

            var Turn1 = new TurnDto();
            Turn1.Players.Add(new PlayerDto { PlayerName = "Armando", Move = 'P' });
            Turn1.Players.Add(new PlayerDto { PlayerName = "Dave", Move = 'S' });
            Game.Turn.Add(Turn1);

            var Turn2 = new TurnDto();
            Turn2.Players.Add(new PlayerDto { PlayerName = "Richard", Move = 'R' });
            Turn2.Players.Add(new PlayerDto { PlayerName = "Michael", Move = 'S' });
            Game.Turn.Add(Turn2);

            var Turn3 = new TurnDto();
            Turn3.Players.Add(new PlayerDto { PlayerName = "Allen", Move = 'S' });
            Turn3.Players.Add(new PlayerDto { PlayerName = "Omer", Move = 'P' });
            Game.Turn.Add(Turn3);

            var Turn4 = new TurnDto();
            Turn4.Players.Add(new PlayerDto { PlayerName = "David E.", Move = 'R' });
            Turn4.Players.Add(new PlayerDto { PlayerName = "Richard X.", Move = 'P' });
            Game.Turn.Add(Turn4);

            return Game;
        }

        public TurnDto AddTurn (List<PlayerDto> players)
        {
            TurnDto Turn = new TurnDto();

            foreach(var player in players)
            {
                Turn.Players.Add(player);
            }

            return Turn;
        }

    }
}
