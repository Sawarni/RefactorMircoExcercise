using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDMicroExercises.TelemetrySystem.Interfaces;

namespace TDDMicroExercises.TelemetrySystem
{
    /// <summary>
    /// This class implements the connection related method for telemetry system.
    /// </summary>
    public class TelemetryConnection : ITelemetryConnection
    {
        private bool _onlineStatus;
        private readonly Random _connectionEventsSimulator = new Random();
        private readonly IConnectionEvent _connectionEvent;

        public bool OnlineStatus
        {
            get { return _onlineStatus; }
        }


        public TelemetryConnection():this(new ConnectionEvent())
        {

        }
        public TelemetryConnection(IConnectionEvent connectionEvent)
        {
            _connectionEvent = connectionEvent;
        }

        public void Connect(string telemetryServerConnectionString)
        {
            if (string.IsNullOrEmpty(telemetryServerConnectionString))
            {
                throw new ArgumentNullException();
            }

            // Fake the connection with 20% chances of success
            bool success = _connectionEvent.CheckConnection();

            _onlineStatus = success;

        }


        public void Disconnect()
        {
            _onlineStatus = false;
        }
    }
}
