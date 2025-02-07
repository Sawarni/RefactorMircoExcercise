using NUnit.Framework;
using Moq;
using TDDMicroExercises.TirePressureMonitoringSystem.Interface;
using TDDMicroExercises.TirePressureMonitoringSystem.Utils;

namespace TDDMicroExercises.TirePressureMonitoringSystem.Tests
{
    [TestFixture]
    public class AlarmTests
    {
        [Test]
        public void Check_when_sensor_reports_lower_threshold_value_then_set_alarm_on()
        {
            Mock<ISensor> _mockSensor = new Mock<ISensor>();
            _mockSensor.Setup(x => x.PopNextPressurePsiValue()).Returns(ThresholdConstants.LowPressureThreshold - 1);

            var alarm = new Alarm(_mockSensor.Object);

            alarm.Check();
            Assert.IsTrue(alarm.AlarmOn);
        }

        [Test]
        public void Check_when_sensor_reports_value_same_as_lower_threshold_value_then_set_alarm_off() //boundary condition lower boundary
        {
            Mock<ISensor> _mockSensor = new Mock<ISensor>();
            _mockSensor.Setup(x => x.PopNextPressurePsiValue()).Returns(ThresholdConstants.LowPressureThreshold);

            var alarm = new Alarm(_mockSensor.Object);

            alarm.Check();
            Assert.IsFalse(alarm.AlarmOn);
        }

        [Test]
        public void Check_when_sensor_reports_higher_threshold_value_then_set_alarm_on()
        {
            Mock<ISensor> _mockSensor = new Mock<ISensor>();
            _mockSensor.Setup(x => x.PopNextPressurePsiValue()).Returns(ThresholdConstants.HighPressureThreshold + 1);

            var alarm = new Alarm(_mockSensor.Object);

            alarm.Check();
            Assert.IsTrue(alarm.AlarmOn);
        }

        [Test]
        public void Check_when_sensor_reports_value_same_as_higher_threshold_value_then_set_alarm_off() //boundary condition upper boundary
        {
            Mock<ISensor> _mockSensor = new Mock<ISensor>();
            _mockSensor.Setup(x => x.PopNextPressurePsiValue()).Returns(ThresholdConstants.HighPressureThreshold);

            var alarm = new Alarm(_mockSensor.Object);

            alarm.Check();
            Assert.IsFalse(alarm.AlarmOn);
        }

        [Test]
        public void Check_when_sensor_reports_value_within_threshold_value_then_set_alarm_off() //boundary condition upper boundary
        {
            Mock<ISensor> _mockSensor = new Mock<ISensor>();
            _mockSensor.Setup(x => x.PopNextPressurePsiValue()).Returns(ThresholdConstants.HighPressureThreshold - 1);

            var alarm = new Alarm(_mockSensor.Object);

            alarm.Check();
            Assert.IsFalse(alarm.AlarmOn);
        }

        [Test]
        public void Check_when_sensor_reports_value_greater_than_threshold_value_and_then_within_threshold_keep_alarm_on() //boundary condition upper boundary
        {
            Mock<ISensor> _mockSensor = new Mock<ISensor>();
            _mockSensor.SetupSequence(x => x.PopNextPressurePsiValue())
                .Returns(ThresholdConstants.HighPressureThreshold + 1)
                .Returns(ThresholdConstants.HighPressureThreshold - 1);

            var alarm = new Alarm(_mockSensor.Object);

            alarm.Check();
            Assert.IsTrue(alarm.AlarmOn);
            alarm.Check();
            Assert.IsTrue(alarm.AlarmOn);
        }

        [Test]
        public void Check_when_sensor_reports_value_lower_than_threshold_value_and_then_within_threshold_keep_alarm_on() //boundary condition upper boundary
        {
            Mock<ISensor> _mockSensor = new Mock<ISensor>();
            _mockSensor.SetupSequence(x => x.PopNextPressurePsiValue())
                .Returns(ThresholdConstants.LowPressureThreshold - 1)
                .Returns(ThresholdConstants.LowPressureThreshold + 1);

            var alarm = new Alarm(_mockSensor.Object);

            alarm.Check();
            Assert.IsTrue(alarm.AlarmOn);
            alarm.Check();
            Assert.IsTrue(alarm.AlarmOn);
        }
    }
}
