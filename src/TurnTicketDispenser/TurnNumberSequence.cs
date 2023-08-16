namespace TDDMicroExercises.TurnTicketDispenser
{
    public static class TurnNumberSequence 
    {
        public static INumberSequence NumberSequence = new NumberSequence();
      
        public static int GetNextTurnNumber()
        {
            return NumberSequence.GetNextTurnNumber();
        }
    }

}
