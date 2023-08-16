namespace TDDMicroExercises.TelemetrySystem.Intefaces
{
    public interface ITelemetryConnection
    {
        bool OnlineStatus { get; }

        void Connect(string telemetryServerConnectionString);
        void Disconnect();
    }
}