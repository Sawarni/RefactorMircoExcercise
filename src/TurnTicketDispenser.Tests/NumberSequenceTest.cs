using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDMicroExercises.TurnTicketDispenser.Tests
{
    [TestFixture]
    public class NumberSequenceTest
    {
        [Test]
        public void Check_NumberSequence_is_singleton()
        {
            var instance1 = NumberSequence.Instance;
            var instance2 = NumberSequence.Instance;
            Assert.AreEqual(instance1, instance2);
            int instance1Fetch = instance1.GetNextTurnNumber();
            int instance2Fetch = instance2.GetNextTurnNumber();
            Assert.AreEqual(instance1Fetch + 1, instance2Fetch);
        }

    }
}
