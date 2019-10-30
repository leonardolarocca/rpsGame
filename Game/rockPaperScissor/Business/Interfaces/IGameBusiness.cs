using rockPaperScissor.Dto;

namespace rockPaperScissor.Business.Interfaces
{
    public interface IGameBusiness
    {
        string RpsGameWinner(GameDto Game);
        PlayerDto RunTurn(TurnDto Turn);
        GameDto GenerateNewTurn(GameDto Game);

    }
}