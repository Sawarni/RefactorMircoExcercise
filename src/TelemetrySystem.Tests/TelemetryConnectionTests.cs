using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDMicroExercises.TelemetrySystem.Interfaces;

namespace TDDMicroExercises.TelemetrySystem.Tests
{
    [TestFixture]
    public class TelemetryConnectionTests
    {
        [Test]
        public void Check_connection_when_connection_event_fails()
        {
            Mock<IConnectionEvent> mockConnectionEvent = new Mock<IConnectionEvent>();
            mockConnectionEvent.Setup(x => x.CheckConnection()).Returns(false);

            var telemetryConnection = new TelemetryConnection(mockConnectionEvent.Object);
            telemetryConnection.Connect("abcd");

            Assert.IsFalse(telemetryConnection.OnlineStatus);
            

        }

        [Test]
        public void Check_connection_when_connection_event_succeed()
        {
            Mock<IConnectionEvent> mockConnectionEvent = new Mock<IConnectionEvent>();
            mockConnectionEvent.Setup(x => x.CheckConnection()).Returns(true);

            var telemetryConnection = new TelemetryConnection(mockConnectionEvent.Object);
            telemetryConnection.Connect("abcd");

            Assert.IsTrue(telemetryConnection.OnlineStatus);

        }

        [Test]
        public void Check_connection_when_connection_was_disconnected_after_successful_connection()
        {
            Mock<IConnectionEvent> mockConnectionEvent = new Mock<IConnectionEvent>();
            mockConnectionEvent.Setup(x => x.CheckConnection()).Returns(true);

            var telemetryConnection = new TelemetryConnection(mockConnectionEvent.Object);
            telemetryConnection.Connect("abcd");

            Assert.IsTrue(telemetryConnection.OnlineStatus); //connection is established

            telemetryConnection.Disconnect();

            Assert.IsFalse(telemetryConnection.OnlineStatus); //connection is disconnected

        }

        [Test]
        public void Check_connection_should_throw_an_exception_when_null_connection_string_passed()
        {
            var telemetryConnection = new TelemetryConnection();
            Assert.Throws<ArgumentNullException>(() => telemetryConnection.Connect(null));
        }

        [Test]
        public void Check_connection_should_throw_an_exception_when_empty_connection_string_passed()
        {
            var telemetryConnection = new TelemetryConnection();
            Assert.Throws<ArgumentNullException>(() => telemetryConnection.Connect(String.Empty));
        }
    }
}
