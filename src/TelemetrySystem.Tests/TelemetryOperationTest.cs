using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDMicroExercises.TelemetrySystem.Utils;

namespace TDDMicroExercises.TelemetrySystem.Tests
{
    [TestFixture]
    public class TelemetryOperationTest
    {
        [Test]
        public void Send_should_throw_an_argument_null_exception_when_null_message_is_passed()
        {
            var telemetryOperation = new TelemertryOperation();
            Assert.Throws<ArgumentNullException>(() => telemetryOperation.Send(null));
        }

        [Test]
        public void Send_should_throw_an_argument_null_exception_when_empty_message_is_passed()
        {
            var telemetryOperation = new TelemertryOperation();
            Assert.Throws<ArgumentNullException>(() => telemetryOperation.Send(string.Empty));
        }

        [Test]
        public void Receive_should_get_specific_message_when_diagnostic_message_is_sent()
        {
            var telemetryOperation = new TelemertryOperation();
            telemetryOperation.Send(TelemetryConstants.DiagnosticMessage);
            var expectedMessage = TelemetryConstants.DiagnosticMessageResponse;
            var receiveMessage = telemetryOperation.Receive();
            Assert.AreEqual(expectedMessage, receiveMessage);
        }

        [Test]
        public void Receive_should_get_random_message_when_diagnostic_message_is_sent()
        {
            var telemetryOperation = new TelemertryOperation();
            telemetryOperation.Send("abcd");
            var receiveMessage = telemetryOperation.Receive();
            Assert.IsNotEmpty(receiveMessage);
        }
    }
}
