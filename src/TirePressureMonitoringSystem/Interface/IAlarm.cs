namespace TDDMicroExercises.TirePressureMonitoringSystem.Interface
{
    public interface IAlarm
    {
        bool AlarmOn { get; }

        void Check();
    }
}