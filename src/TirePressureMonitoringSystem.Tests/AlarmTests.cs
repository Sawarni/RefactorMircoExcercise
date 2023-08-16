using NUnit.Framework;
using Moq;
using TDDMicroExercises.TirePressureMonitoringSystem.Interface;

namespace TDDMicroExercises.TirePressureMonitoringSystem.Tests
{
    [TestFixture]
    public class AlarmTests
    {
        [Test]
        public void Check_when_sensor_reports_lower_threshold_value_then_set_alarm_on()
        {
            Mock<ISensor> _mockSensor = new Mock<ISensor>();
            _mockSensor.Setup(x => x.PopNextPressurePsiValue()).Returns(16);

            var alarm = new Alarm(_mockSensor.Object);

            alarm.Check();
            Assert.IsTrue(alarm.AlarmOn);
        }

        [Test]
        public void Check_when_sensor_reports_value_same_as_lower_threshold_value_then_set_alarm_off() //boundary condition lower boundary
        {
            Mock<ISensor> _mockSensor = new Mock<ISensor>();
            _mockSensor.Setup(x => x.PopNextPressurePsiValue()).Returns(17);

            var alarm = new Alarm(_mockSensor.Object);

            alarm.Check();
            Assert.IsFalse(alarm.AlarmOn);
        }

        [Test]
        public void Check_when_sensor_reports_higher_threshold_value_then_set_alarm_on()
        {
            Mock<ISensor> _mockSensor = new Mock<ISensor>();
            _mockSensor.Setup(x => x.PopNextPressurePsiValue()).Returns(22);

            var alarm = new Alarm(_mockSensor.Object);

            alarm.Check();
            Assert.IsTrue(alarm.AlarmOn);
        }

        [Test]
        public void Check_when_sensor_reports_value_same_as_higher_threshold_value_then_set_alarm_off() //boundary condition upper boundary
        {
            Mock<ISensor> _mockSensor = new Mock<ISensor>();
            _mockSensor.Setup(x => x.PopNextPressurePsiValue()).Returns(21);

            var alarm = new Alarm(_mockSensor.Object);

            alarm.Check();
            Assert.IsFalse(alarm.AlarmOn);
        }

        [Test]
        public void Check_when_sensor_reports_value_within_threshold_value_then_set_alarm_off() //boundary condition upper boundary
        {
            Mock<ISensor> _mockSensor = new Mock<ISensor>();
            _mockSensor.Setup(x => x.PopNextPressurePsiValue()).Returns(19);

            var alarm = new Alarm(_mockSensor.Object);

            alarm.Check();
            Assert.IsFalse(alarm.AlarmOn);
        }
    }
}
