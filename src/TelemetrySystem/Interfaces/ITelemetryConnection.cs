namespace TDDMicroExercises.TelemetrySystem.Interfaces
{
    /// <summary>
    /// The interface for Telemetry connection
    /// </summary>
    public interface ITelemetryConnection
    {
        bool OnlineStatus { get; }

        void Connect(string telemetryServerConnectionString);
        void Disconnect();
    }
}