using System.Collections.Generic;

namespace rockPaperScissor.Dto
{
    public class TurnDto
    {
        public List<PlayerDto> Players { get; set; }

        public TurnDto()
        {
            Players = new List<PlayerDto>();
        }
    }
}
