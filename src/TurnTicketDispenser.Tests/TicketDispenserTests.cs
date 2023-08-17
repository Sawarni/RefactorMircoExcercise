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
            var returnValue = turnTicketDispenser.GetTurnTicket();

            Assert.AreEqual(6, returnValue.TurnNumber);
        }

        [Test]
        public void Check_TurnTicket_when_Multiple_dispensers_are_present()
        {
            var turnTicketDispenser1 = new TicketDispenser();
            var turnTicketDispenser2 = new TicketDispenser();
            var returnValue0 = turnTicketDispenser1.GetTurnTicket();
            var returnValue1 = turnTicketDispenser1.GetTurnTicket();
            var returnValue2 = turnTicketDispenser2.GetTurnTicket();
            var returnValue3 = turnTicketDispenser1.GetTurnTicket();
            var returnValue4 = turnTicketDispenser2.GetTurnTicket();
            Assert.AreEqual(returnValue0.TurnNumber + 1, returnValue1.TurnNumber);
            Assert.AreEqual(returnValue1.TurnNumber + 1, returnValue2.TurnNumber);
            Assert.AreEqual(returnValue2.TurnNumber + 1, returnValue3.TurnNumber);
            Assert.AreEqual(returnValue3.TurnNumber + 1, returnValue4.TurnNumber);

            var turnTicketDispenser3 = new TicketDispenser();
            var returnValue5 = turnTicketDispenser3.GetTurnTicket();
            Assert.AreEqual(returnValue4.TurnNumber + 1, returnValue5.TurnNumber);
        }

      
    }
}
