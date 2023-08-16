namespace TDDMicroExercises.TelemetrySystem.Intefaces
{
    public interface ITelemetryDiagnosticControls
    {
        string DiagnosticInfo { get; set; }

        void CheckTransmission();
    }
}