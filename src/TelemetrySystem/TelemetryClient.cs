using System;
using TDDMicroExercises.TelemetrySystem.Intefaces;

namespace TDDMicroExercises.TelemetrySystem
{
    public class TelemetryClient : ITelemetryClient
    {
        private readonly ITelimetryOperation _operation;
        private readonly ITelemetryConnection _connection;

        public TelemetryClient(ITelimetryOperation operation, ITelemetryConnection connection)
        {
            _operation = operation;
            _connection = connection;
        }

        /// <summary>
        /// Implemented this constructor so that the dependent client does not break.
        /// </summary>
        public TelemetryClient() : this(new TelemertryOperation(), new TelimetryConnection())
        {

        }
        public bool OnlineStatus
        {
            get { return _connection.OnlineStatus; }
        }
        public void Connect(string telemetryServerConnectionString)
        {
            _connection.Connect(telemetryServerConnectionString);
        }

        public void Disconnect()
        {
            _connection.Disconnect();
        }

        public void Send(string message)
        {
            _operation.Send(message);
        }

        public string Receive()
        {
            return _operation.Receive();
        }
    }
}
