namespace TDDMicroExercises.TelemetrySystem.Interfaces
{
    /// <summary>
    /// An interface to enforce implementation of telemetry connection and telimetry operation
    /// </summary>
    public interface ITelemetryClient : ITelemetryConnection, ITelemetryOperation
    {

    }
}