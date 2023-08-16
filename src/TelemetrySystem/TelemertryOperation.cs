﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDMicroExercises.TelemetrySystem.Intefaces;
using TDDMicroExercises.TelemetrySystem.Utils;

namespace TDDMicroExercises.TelemetrySystem
{
    /// <summary>
    /// Sawarni Manu : In order to implement SRP (Single responsibilty principle)
    /// </summary>
    public class TelemertryOperation : ITelimetryOperation // Implement an interface purely responsible for telemtery operation Send and Receive.
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
                message = "LAST TX rate................ 100 MBPS\r\n"
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
