using NUnit.Framework;
using Moq;
using TDDMicroExercises.TelemetrySystem.Interfaces;

namespace TDDMicroExercises.TelemetrySystem.Tests
{
    [TestFixture]
    public class TelemetryClientTest
    {
        private Mock<ITelemetryConnection> _telemetryConnection = new Mock<ITelemetryConnection>();
        private Mock<ITelemetryOperation> _telemetryOperation = new Mock<ITelemetryOperation>();

        [Test]
        public void Check_OnlineStatus_when_connection_returns_true()
        {
            _telemetryConnection.Setup(x => x.OnlineStatus).Returns(true);
            var telemetryClient = new TelemetryClient(_telemetryOperation.Object,
                _telemetryConnection.Object);

            Assert.IsTrue(telemetryClient.OnlineStatus);
        }

        [Test]
        public void Check_OnlineStatus_when_connection_returns_false()
        {
            _telemetryConnection.Setup(x => x.OnlineStatus).Returns(false);
            var telemetryClient = new TelemetryClient(_telemetryOperation.Object,
                _telemetryConnection.Object);

            Assert.IsFalse(telemetryClient.OnlineStatus);
        }

        [Test]
        public void Check_TelementryConnection_Connect_is_called_when_invoking_connect_method()
        {
            _telemetryConnection.Setup(x => x.Connect(It.IsAny<string>()));
            var telemetryClient = new TelemetryClient(_telemetryOperation.Object,
                _telemetryConnection.Object);
            telemetryClient.Connect("abcd");
            _telemetryConnection.Verify(x => x.Connect(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void Check_TelementryConnection_Disconnect_is_called_when_invoking_disconnect_method()
        {
            _telemetryConnection.Setup(x => x.Disconnect());
            var telemetryClient = new TelemetryClient(_telemetryOperation.Object,
                _telemetryConnection.Object);
            telemetryClient.Disconnect();
            _telemetryConnection.Verify(x => x.Disconnect(), Times.Once);
        }

        [Test]
        public void Check_TelementryOperation_send_is_called_when_invoking_send_method()
        {
            _telemetryOperation.Setup(x => x.Send(It.IsAny<string>()));
            var telemetryClient = new TelemetryClient(_telemetryOperation.Object,
                _telemetryConnection.Object);
            telemetryClient.Send("abcd");
            _telemetryOperation.Verify(x => x.Send(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void Check_TelementryOperation_receive_is_called_when_invoking_receive_method()
        {
            _telemetryOperation.Setup(x => x.Receive());
            var telemetryClient = new TelemetryClient(_telemetryOperation.Object,
                _telemetryConnection.Object);
            telemetryClient.Receive();
            _telemetryOperation.Verify(x => x.Receive(), Times.Once);
        }

    }
}
