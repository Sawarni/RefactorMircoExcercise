namespace TDDMicroExercises.TelemetrySystem.Interfaces
{
    /// <summary>
    /// An interface to expose telemetry diagnostic control in future client.
    /// </summary>
    public interface ITelemetryDiagnosticControls
    {
        string DiagnosticInfo { get; set; }

        void CheckTransmission();
    }
}