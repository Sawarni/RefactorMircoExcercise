using TDDMicroExercises.TirePressureMonitoringSystem.Interface;
using TDDMicroExercises.TirePressureMonitoringSystem.Utils;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class Alarm : IAlarm
    {
       
        readonly ISensor _sensor;

        bool _alarmOn = false;

        public Alarm(ISensor sensor)
        {
            _sensor = sensor;
        }

        /// <summary>
        /// Implement a default constructor to avoid breaking of dependent object.
        /// </summary>
        public Alarm() : this(new Sensor())
        {

        }


        public void Check()
        {
            double psiPressureValue = _sensor.PopNextPressurePsiValue();

            if (psiPressureValue < ThresholdConstants.LowPressureThreshold || ThresholdConstants.HighPressureThreshold < psiPressureValue)
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
