using System;
using TDDMicroExercises.TelemetrySystem.Interfaces;

namespace TDDMicroExercises.TelemetrySystem
{
    /// <summary>
    /// A class to simulate telemetry connection connection
    /// </summary>
    public class ConnectionEvent : IConnectionEvent
    {
        private readonly Random _connectionEventsSimulator = new Random();

        /// <summary>
        /// // Fake the connection with 20% chances of success
        /// </summary>
        /// <returns>A connection status</returns>
        public bool CheckConnection()
        {
            return _connectionEventsSimulator.Next(1, 10) <= 2;
        }
    }
}
