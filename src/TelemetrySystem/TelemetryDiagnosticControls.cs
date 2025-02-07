
using System;
using TDDMicroExercises.TelemetrySystem.Interfaces;
using TDDMicroExercises.TelemetrySystem.Utils;

namespace TDDMicroExercises.TelemetrySystem
{
    public class TelemetryDiagnosticControls : ITelemetryDiagnosticControls
    {
        private const string DiagnosticChannelConnectionString = "*111#";

        private readonly ITelemetryClient _telemetryClient;
        private string _diagnosticInfo = string.Empty;

        public TelemetryDiagnosticControls(ITelemetryClient telemetryClient)
        {
            _telemetryClient = telemetryClient;
        }

        /// <summary>
        /// Implement a constructor so that dependent objects should not break.
        /// </summary>
        public TelemetryDiagnosticControls() : this(new TelemetryClient())
        {
            
        }

        public string DiagnosticInfo
        {
            get { return _diagnosticInfo; }
            set { _diagnosticInfo = value; }
        }

        public void CheckTransmission()
        {
            _diagnosticInfo = string.Empty;

            _telemetryClient.Disconnect();

            int retryLeft = 3;
            while (_telemetryClient.OnlineStatus == false && retryLeft > 0)
            {
                _telemetryClient.Connect(DiagnosticChannelConnectionString);
                retryLeft -= 1;
            }

            if (_telemetryClient.OnlineStatus == false)
            {
                throw new Exception("Unable to connect.");
            }

            _telemetryClient.Send(TelemetryConstants.DiagnosticMessage);
            _diagnosticInfo = _telemetryClient.Receive();
        }
    }
}
