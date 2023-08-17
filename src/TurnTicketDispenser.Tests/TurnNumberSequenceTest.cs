using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDMicroExercises.TurnTicketDispenser.Tests
{
    [TestFixture]
    public class TurnNumberSequenceTest
    {

        [Test]
        public void Check_TurnNumberSequence_FetchNextNumber_should_always_return_a_running_number_with_one_object()
        {
            TurnNumberSequence sequence1 = new TurnNumberSequence();
            int fetch1 = sequence1.FetchNextNumber();
            int fetch2 = sequence1.FetchNextNumber();
            Assert.AreEqual(fetch1 + 1, fetch2);

        }

        [Test]
        public void Check_TurnNumberSequence_FetchNextNumber_should_always_return_a_running_number_even_when_there_are_multiple_object()
        {
            TurnNumberSequence sequence1 = new TurnNumberSequence();
            TurnNumberSequence sequence2 = new TurnNumberSequence();
            int fetch1 = sequence1.FetchNextNumber();
            int fetch2 = sequence2.FetchNextNumber();
            Assert.AreEqual(fetch1 + 1, fetch2);
            TurnNumberSequence sequence3 = new TurnNumberSequence();
            int fetch3 = sequence3.FetchNextNumber();
            Assert.AreEqual(fetch2 + 1, fetch3);
        }

        [Test]
        public void Check_GetNextTurnNumber_should_also_give_the_next_number()
        {

            int number1 = TurnNumberSequence.GetNextTurnNumber();
            int number2 = TurnNumberSequence.GetNextTurnNumber();
            Assert.AreEqual(number1 + 1, number2);
            int number3 = TurnNumberSequence.GetNextTurnNumber();
            Assert.AreEqual(number2 + 1, number3);

        }
    }
}
