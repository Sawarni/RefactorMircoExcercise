namespace TDDMicroExercises.TurnTicketDispenser
{
    public class TicketDispenser
    {
       
        public ITurnTicket GetTurnTicket()
        {
            int newTurnNumber = TurnNumberSequence.GetNextTurnNumber();
            var newTurnTicket = new TurnTicket(newTurnNumber);

            return newTurnTicket;
        }
    }
}
