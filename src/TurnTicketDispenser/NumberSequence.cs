namespace TDDMicroExercises.TurnTicketDispenser
{
    public class NumberSequence : INumberSequence
    {
        private static int _turnNumber = 0;
        public int GetNextTurnNumber()
        {
            return _turnNumber++;
        }
    }

}
