using NUnit.Framework;
using Moq;
using System;
using TDDMicroExercises.TelemetrySystem.Interfaces;

namespace TDDMicroExercises.TelemetrySystem.Tests
{
    [TestFixture]
    public class TelemetryDiagnosticControlsTest
    {


        [Test]
        public void CheckTransmission_should_send_a_diagnostic_message_and_receive_a_status_message_response()
        {
            Mock<ITelemetryClient> _telemetryClient = new Mock<ITelemetryClient>();
            _telemetryClient.Setup(x => x.Disconnect());
            _telemetryClient.Setup(x => x.Connect(It.IsAny<string>())).Callback(() =>
            {
                _telemetryClient.Setup(x => x.OnlineStatus).Returns(true);
            });
            _telemetryClient.Setup(x => x.Send(Utils.TelemetryConstants.DiagnosticMessage));
            _telemetryClient.Setup(x => x.Receive()).Returns(() => "status message");

            var telemetryDiagnosticControl = new TelemetryDiagnosticControls(_telemetryClient.Object);

            telemetryDiagnosticControl.CheckTransmission();

            _telemetryClient.Verify(x => x.Disconnect(), Times.Once);
            _telemetryClient.Verify(x => x.Connect(It.IsAny<string>()), Times.AtLeastOnce);
            _telemetryClient.Verify(x => x.Send(Utils.TelemetryConstants.DiagnosticMessage), Times.Once);
            _telemetryClient.Verify(x => x.Receive(), Times.Once);
            Assert.AreEqual("status message", telemetryDiagnosticControl.DiagnosticInfo);

        }

        [Test]
        public void CheckTransmission_should_throw_exception_when_connection_failed()
        {
            Mock<ITelemetryClient> _telemetryClient = new Mock<ITelemetryClient>();
            _telemetryClient.Setup(x => x.Disconnect());
            _telemetryClient.Setup(x => x.Connect(It.IsAny<string>()));
            _telemetryClient.Setup(x => x.Send(It.IsAny<string>()));
            _telemetryClient.Setup(x => x.Receive()).Returns(() => "status message");

            var telemetryDiagnosticControl = new TelemetryDiagnosticControls(_telemetryClient.Object);

            Assert.Throws<Exception>(() => telemetryDiagnosticControl.CheckTransmission());

            _telemetryClient.Verify(x => x.Disconnect(), Times.Once); //Call disconnect before making connection
            _telemetryClient.Verify(x => x.Connect(It.IsAny<string>()), Times.Exactly(3)); //Should have tried 3 times
            _telemetryClient.Verify(x => x.Send(It.IsAny<string>()), Times.Never); // Since the connection failed no send method should be called.
            _telemetryClient.Verify(x => x.Receive(), Times.Never); // Since the connection failed, no receive method should be called.
        }

    }
}
