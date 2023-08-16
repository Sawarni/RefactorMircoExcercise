using NUnit.Framework;
using Moq;

namespace TDDMicroExercises.TurnTicketDispenser.Tests
{
    [TestFixture]
    public class TicketDispenserTests
    {
        [Test]
        public void Check_TurnTicket_when_current_count_is_five()
        {
            Mock<INumberSequence> mockNumberSequence = new Mock<INumberSequence>();
            mockNumberSequence.Setup(x => x.GetNextTurnNumber()).Returns(6);
            TurnNumberSequence.NumberSequence = mockNumberSequence.Object;

            var turnTicketDispenser = new TicketDispenser();
            var returnValue =  turnTicketDispenser.GetTurnTicket();

            Assert.AreEqual(6, returnValue.TurnNumber);
        }

        [Test]
        public void Check_TurnTicket_when_Multiple_dispensers_are_present()
        {
            var turnTicketDispenser1 = new TicketDispenser();
            var turnTicketDispenser2 = new TicketDispenser();
            var returnValue1 = turnTicketDispenser1.GetTurnTicket();
            var returnValue2 = turnTicketDispenser2.GetTurnTicket();
            var returnValue3 = turnTicketDispenser1.GetTurnTicket();
            var returnValue4 = turnTicketDispenser2.GetTurnTicket();
            Assert.AreEqual(0, returnValue1.TurnNumber);
            Assert.AreEqual(1, returnValue2.TurnNumber);
            Assert.AreEqual(2, returnValue3.TurnNumber);
            Assert.AreEqual(3, returnValue4.TurnNumber);
        }
    }
}
