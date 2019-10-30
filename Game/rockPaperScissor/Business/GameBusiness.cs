using rockPaperScissor.Business.Interfaces;
using rockPaperScissor.Dto;
using rockPaperScissor.Repository;
using rockPaperScissor.Repository.Interfaces;
using System;
using System.Collections.Generic;

namespace rockPaperScissor.Business
{
    public class GameBusiness : IGameBusiness
    {
        public const string ERROR_MESSAGE_NUMBER_PLAYERS_INCORRECT = "WrongNumberOfPlayersError";
        public const string ERROR_MESSAGE_STRATEGY_ERROR = "NoSuchStrategyError";

        private readonly IGameRepository GameRepository;

        public GameBusiness(IGameRepository GameRepository)
        {
            this.GameRepository = GameRepository;
        }

        public GameBusiness()
            : this(new GameRepository())
        { }

        public string RpsGameWinner(GameDto Game)
        {
            while (Game.Turn.Count > 1)
            {
                foreach (var Turn in Game.Turn)
                {
                    var winPlayer = RunTurn(Turn);
                    Turn.Players.Clear();
                    Turn.Players.Add(winPlayer);
                }
                GenerateNewTurn(Game);
            }
            var winningPlayer = RunTurn(Game.Turn[0]);
            return $"['{winningPlayer.PlayerName}', '{winningPlayer.Move}']";
        }

        public GameDto GenerateNewTurn (GameDto Game)
        {
            var tempPlayers = new List<PlayerDto>();

            foreach(var Turn in Game.Turn)
            {
                foreach(var Player in Turn.Players)
                {
                    tempPlayers.Add(Player);
                }                
            }

            Game.Turn.Clear();
            
            for (int i = 0; i < tempPlayers.ToArray().Length; i++)
            {
                if (i % 2 == 0)
                {
                    var List = new List<PlayerDto>();
                    List.Add(tempPlayers[i]);
                    List.Add(tempPlayers[i+1]);
                    Game.Turn.Add(GameRepository.AddTurn(List));
                }
            }
            return Game;
        }

        public PlayerDto RunTurn(TurnDto Turn)
        {
            if (Turn.Players.Count != 2)
                throw new Exception(ERROR_MESSAGE_NUMBER_PLAYERS_INCORRECT);

            var p1 = Turn.Players[0];
            var p2 = Turn.Players[1];

            if (p1.Move == p2.Move)
                return p1;

            switch (p1.Move)
            {
                case 'R':
                    return p2.Move == 'S' ? p1 : p2;
                case 'P':
                    return p2.Move == 'R' ? p1 : p2;
                case 'S':
                    return p2.Move == 'P' ? p1 : p2;
                default:
                    throw new Exception(message: ERROR_MESSAGE_STRATEGY_ERROR);
            }

        }
    }
}
