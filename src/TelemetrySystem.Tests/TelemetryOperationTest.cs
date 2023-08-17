using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDMicroExercises.TelemetrySystem.Tests
{
    [TestFixture]
    public class TelemetryOperationTest
    {
        [Test]
        public void Send_should_throw_an_exception_when_null_argument_is_passed()
        {
            var telemetryOperation = new TelemertryOperation();
            Assert.Throws<ArgumentNullException>(() => telemetryOperation.Send(null));
        }

        [Test]
        public void Receive_should_get_specific_message_when_diagnostic_message_is_sent()
        {
            var telemetryOperation = new TelemertryOperation();
            telemetryOperation.Send(Utils.TelemetryConstants.DiagnosticMessage);
            var expectedMessage = "LAST TX rate................ 100 MBPS\r\n"
                    + "HIGHEST TX rate............. 100 MBPS\r\n"
                    + "LAST RX rate................ 100 MBPS\r\n"
                    + "HIGHEST RX rate............. 100 MBPS\r\n"
                    + "BIT RATE.................... 100000000\r\n"
                    + "WORD LEN.................... 16\r\n"
                    + "WORD/FRAME.................. 511\r\n"
                    + "BITS/FRAME.................. 8192\r\n"
                    + "MODULATION TYPE............. PCM/FM\r\n"
                    + "TX Digital Los.............. 0.75\r\n"
                    + "RX Digital Los.............. 0.10\r\n"
                    + "BEP Test.................... -5\r\n"
                    + "Local Rtrn Count............ 00\r\n"
                    + "Remote Rtrn Count........... 00";
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
