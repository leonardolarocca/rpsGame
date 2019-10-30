using rockPaperScissor.Dto;

namespace rockPaperScissorTests.Fakes.Dto
{
    public static class TurnDtoFake
    {
        public static TurnDto GetInitialized()
        {
            return new TurnDto();
        }

        public static TurnDto GetFilled()
        {
            var Turn = GetInitialized();
            Turn.Players.Add(new PlayerDto { PlayerName = "Leonard", Move = 'P' });
            Turn.Players.Add(new PlayerDto { PlayerName = "Gregory", Move = 'R' });
            return Turn;
        }

        public static TurnDto GetFilledWithWrongNumberOfPlayers()
        {
            var Turn = GetInitialized();
            Turn.Players.Add(new PlayerDto { PlayerName = "Leonard", Move = 'P' });
            return Turn;
        }

        public static TurnDto GetFilledWithWrongChoiceMove()
        {
            var Turn = GetInitialized();
            Turn.Players.Add(new PlayerDto { PlayerName = "Leonard", Move = 'J' });
            Turn.Players.Add(new PlayerDto { PlayerName = "Gregory", Move = 'N' });
            return Turn;
        }
    }
}
