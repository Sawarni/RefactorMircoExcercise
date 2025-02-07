using TDDMicroExercises.TurnTicketDispenser.Interfaces;

namespace TDDMicroExercises.TurnTicketDispenser
{
    public class NumberSequence : INumberSequence
    {
        private static readonly object lockObject = new object();
        private static NumberSequence instance;

        private int _turnNumber = 0;

        public static NumberSequence Instance
        {
            get
            {
                lock(lockObject)
                {
                    if(instance == null)
                    {
                        instance = new NumberSequence();
                    }
                    return instance;
                }
            }
        }
        private NumberSequence()
        {

        }

        public int GetNextTurnNumber()
        {
            return _turnNumber++;
        }
    }

}
