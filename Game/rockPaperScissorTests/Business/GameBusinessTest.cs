using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using rockPaperScissor.Business;
using rockPaperScissor.Business.Interfaces;
using rockPaperScissor.Dto;
using rockPaperScissorTests.Fakes.Dto;
using System;

namespace rockPaperScissorTests.Business
{
    [TestFixture]
    public class GameBusinessTest
    {
        public const string ERROR_MESSAGE_NUMBER_PLAYERS_INCORRECT = "WrongNumberOfPlayersError";
        public const string ERROR_MESSAGE_STRATEGY_ERROR = "NoSuchStrategyError";

        private IGameBusiness GameBusiness;
        private PlayerDto Player;

        [SetUp]
        public void SetUp ()
        {
            Player = PlayerDtoFake.GetFilled();
            GameBusiness = Substitute.For<IGameBusiness>();
            GameBusiness = new GameBusiness();
        }

        [TestCase(TestName = "[RPS] Should be return the winner of Turn")]
        public void Should_be_return_the_winner_of_game ()
        {
            var turn = TurnDtoFake.GetFilled();
            var obtained = GameBusiness.RunTurn(turn);
            obtained.Should().BeEquivalentTo(Player);
        }

        [TestCase(TestName = "[RPS] Should be return exception message for wrong number of players")]
        public void Should_be_return_exception_for_wrong_number_of_players ()
        {
            var turn = TurnDtoFake.GetFilledWithWrongNumberOfPlayers();
            var exception = Assert.Throws<Exception>(() => GameBusiness.RunTurn(turn));            
            exception.Message.Should().Be(ERROR_MESSAGE_NUMBER_PLAYERS_INCORRECT);
        }

        [TestCase(TestName = "[RPS] Should be return exception message for wrong choice of move")]
        public void Should_be_return_exception_for_wrong_choice_of_move()
        {
            var turn = TurnDtoFake.GetFilledWithWrongChoiceMove();
            var exception = Assert.Throws<Exception>(() => GameBusiness.RunTurn(turn));
            exception.Message.Should().Be(ERROR_MESSAGE_STRATEGY_ERROR);
        }
    }
}
