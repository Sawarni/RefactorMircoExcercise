using System;
using TDDMicroExercises.TelemetrySystem.Interfaces;
using TDDMicroExercises.TelemetrySystem.Utils;

namespace TDDMicroExercises.TelemetrySystem
{
    /// <summary>
    /// This class implements the operations like Send and Receive of Telemetry
    /// </summary>
    public class TelemertryOperation : ITelemetryOperation // Implement an interface purely responsible for telemtery operation Send and Receive.
    {
       
        private bool _diagnosticMessageJustSent = false;
        private readonly Random _randomMessageSimulator = new Random();
        public void Send(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentNullException();
            }

            // The simulation of Send() actually just remember if the last message sent was a diagnostic message.
            // This information will be used to simulate the Receive(). Indeed there is no real server listening.
            if (message == TelemetryConstants.DiagnosticMessage)
            {
                _diagnosticMessageJustSent = true;
            }
            else
            {
                _diagnosticMessageJustSent = false;
            }
        }

        public string Receive()
        {
            string message;

            if (_diagnosticMessageJustSent)
            {
                // Simulate the reception of the diagnostic message
                message = TelemetryConstants.DiagnosticMessageResponse;

                _diagnosticMessageJustSent = false;
            }
            else
            {
                // Simulate the reception of a response message returning a random message.
                message = string.Empty;
                int messageLength = _randomMessageSimulator.Next(50, 110);
                for (int i = messageLength; i > 0; --i)
                {
                    message += (char)_randomMessageSimulator.Next(40, 126);
                }
            }

            return message;
        }
    }
}
