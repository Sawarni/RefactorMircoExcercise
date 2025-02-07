namespace TDDMicroExercises.TirePressureMonitoringSystem.Interface
{
    /// <summary>
    /// Interface to expose functionality of alarm to future clients.
    /// </summary>
    public interface IAlarm
    {
        bool AlarmOn { get; }

        void Check();
    }
}