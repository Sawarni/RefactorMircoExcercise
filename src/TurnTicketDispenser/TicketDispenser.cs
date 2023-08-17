using TDDMicroExercises.TurnTicketDispenser.Interfaces;

namespace TDDMicroExercises.TurnTicketDispenser
{
    public class TicketDispenser : ITicketDispenser
    {
        private readonly ITurnNumberSequence _turnNumberSequence;

        public TicketDispenser() : this(new TurnNumberSequence())
        {
        }

        public TicketDispenser(ITurnNumberSequence turnNumberSequence)
        {
            _turnNumberSequence = turnNumberSequence;
        }

        public ITurnTicket GetTurnTicket()
        {
            int newTurnNumber = _turnNumberSequence.FetchNextNumber();
            ITurnTicket newTurnTicket = GetTurnTicket(newTurnNumber);

            return newTurnTicket;
        }

        /// <summary>
        /// A simple factory method to provide Turn ticket. In future could be extended to provide 
        /// different implementation of ITurnTicket
        /// </summary>
        /// <param name="newTurnNumber">A integer indicating current turn number.</param>
        /// <returns></returns>
        private ITurnTicket GetTurnTicket(int newTurnNumber)
        {
            return new TurnTicket(newTurnNumber);
        }
    }
}
