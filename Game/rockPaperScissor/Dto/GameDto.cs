using System.Collections.Generic;

namespace rockPaperScissor.Dto
{
    public class GameDto
    {
        public List<TurnDto> Turn { get; set; }


        public GameDto()
        {
            Turn = new List<TurnDto>();
        }
    }
}
