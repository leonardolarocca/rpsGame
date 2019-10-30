using rockPaperScissor.Dto;
using System.Collections.Generic;

namespace rockPaperScissor.Repository.Interfaces
{
    public interface IGameRepository
    {
        GameDto GetGame();
        TurnDto AddTurn(List<PlayerDto> players);
    }
}