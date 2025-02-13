using TDDMicroExercises.TurnTicketDispenser.Interfaces;

namespace TDDMicroExercises.TurnTicketDispenser
{
    public class TurnTicket : ITurnTicket
    {
        private readonly int _turnNumber;

        public TurnTicket(int turnNumber)
        {
            _turnNumber = turnNumber;
        }

        public int TurnNumber
        {
            get { return _turnNumber; }
        }

    }
}