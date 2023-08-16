namespace TDDMicroExercises.TelemetrySystem.Intefaces
{
    public interface ITelimetryOperation
    {
        string Receive();
        void Send(string message);
    }
}
