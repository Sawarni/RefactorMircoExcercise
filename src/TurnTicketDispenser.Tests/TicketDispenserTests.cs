using NUnit.Framework;
using Moq;
using TDDMicroExercises.TurnTicketDispenser.Interfaces;

namespace TDDMicroExercises.TurnTicketDispenser.Tests
{
    [TestFixture]
    public class TicketDispenserTests
    {
        [Test]
        public void Check_TurnTicket_when_current_count_is_five()
        {
            Mock<ITurnNumberSequence> mockTurnNumberSequence = new Mock<ITurnNumberSequence>();
            mockTurnNumberSequence.Setup(x => x.FetchNextNumber()).Returns(6);
            var turnTicketDispenser = new TicketDispenser(mockTurnNumberSequence.Object);
            var turnTicket = turnTicketDispenser.GetTurnTicket();

            Assert.AreEqual(6, turnTicket.TurnNumber);
        }

        [Test]
        public void Check_TurnTicket_have_subsequent_number_when_dispensed_through_multiple_dispensers()
        {
            var turnTicketDispenser1 = new TicketDispenser();
            var turnTicketDispenser2 = new TicketDispenser();
            var firstTicketFromDispenser1 = turnTicketDispenser1.GetTurnTicket();
            var secondTicketFromDispenser1 = turnTicketDispenser1.GetTurnTicket();
            var firstTicketFromDispenser2 = turnTicketDispenser2.GetTurnTicket();
            var thirdTicketFromDispenser1 = turnTicketDispenser1.GetTurnTicket();
            var secondTicketFromDispenser2 = turnTicketDispenser2.GetTurnTicket();
            Assert.AreEqual(firstTicketFromDispenser1.TurnNumber + 1, secondTicketFromDispenser1.TurnNumber);
            Assert.AreEqual(secondTicketFromDispenser1.TurnNumber + 1, firstTicketFromDispenser2.TurnNumber);
            Assert.AreEqual(firstTicketFromDispenser2.TurnNumber + 1, thirdTicketFromDispenser1.TurnNumber);
            Assert.AreEqual(thirdTicketFromDispenser1.TurnNumber + 1, secondTicketFromDispenser2.TurnNumber);

            var turnTicketDispenser3 = new TicketDispenser();
            var firstTicketFromDispenser3 = turnTicketDispenser3.GetTurnTicket();
            Assert.AreEqual(secondTicketFromDispenser2.TurnNumber + 1, firstTicketFromDispenser3.TurnNumber);
        }

        [Test]
        public void Check_TurnTicket_have_subsequent_number_when_dispensed_through_single_dispenser()
        {
            var turnTicketDispenser1 = new TicketDispenser();
            var firstTicket = turnTicketDispenser1.GetTurnTicket();
            var secondTicket = turnTicketDispenser1.GetTurnTicket();

            Assert.AreEqual(firstTicket.TurnNumber + 1, secondTicket.TurnNumber);

        }


    }
}
