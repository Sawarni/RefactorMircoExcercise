using TDDMicroExercises.TirePressureMonitoringSystem.Interface;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class Alarm : IAlarm
    {
        private const double LowPressureThreshold = 17;
        private const double HighPressureThreshold = 21;

        readonly ISensor _sensor;

        bool _alarmOn = false;

        public Alarm(ISensor sensor)
        {
            _sensor = sensor;
        }

        public Alarm()
        {
            _sensor = new Sensor();
        }


        public void Check()
        {
            double psiPressureValue = _sensor.PopNextPressurePsiValue();

            if (psiPressureValue < LowPressureThreshold || HighPressureThreshold < psiPressureValue)
            {
                _alarmOn = true;
            }
        }

        public bool AlarmOn
        {
            get { return _alarmOn; }
        }

    }
}
