namespace TDDMicroExercises.TelemetrySystem.Interfaces
{
    /// <summary>
    /// An interface to implement telemtry operation
    /// </summary>
    public interface ITelemetryOperation
    {
        string Receive();
        void Send(string message);
    }
}
