using TDDMicroExercises.TelemetrySystem.Interfaces;

namespace TDDMicroExercises.TelemetrySystem
{
    /// <summary>
    /// Telemetry client is a facade which internally calls Telemetry Operation and Connection.
    /// It is necessary to have this class as there are exisitng dependency which cannot be changed.
    /// </summary>
    public class TelemetryClient : ITelemetryClient
    {
        private readonly ITelemetryOperation _operation;
        private readonly ITelemetryConnection _connection;

        public TelemetryClient(ITelemetryOperation operation, ITelemetryConnection connection)
        {
            _operation = operation;
            _connection = connection;
        }

        /// <summary>
        /// Implemented this constructor so that the dependent client does not break.
        /// </summary>
        public TelemetryClient() : this(new TelemertryOperation(), new TelemetryConnection())
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
