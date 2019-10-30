using rockPaperScissor.Dto;

namespace rockPaperScissorTests.Fakes.Dto
{
    public static class PlayerDtoFake
    {
        public static PlayerDto GetInitialized ()
        {
            return new PlayerDto();
        }

        public static PlayerDto GetFilled ()
        {
            var Player = GetInitialized();
            Player.PlayerName = "Leonard";
            Player.Move = 'P';
            return Player;
        }
        
    }
}
