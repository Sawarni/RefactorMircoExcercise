using TDDMicroExercises.TurnTicketDispenser.Interfaces;

namespace TDDMicroExercises.TurnTicketDispenser
{
    public class TurnNumberSequence : ITurnNumberSequence
    {
        private INumberSequence NumberSequenceInstance;
        public TurnNumberSequence()
        {
            NumberSequenceInstance = NumberSequence.Instance;
        }

        public TurnNumberSequence(INumberSequence numberSequence)
        {
            NumberSequenceInstance = numberSequence;
        }
        public static int GetNextTurnNumber() //Need this method as it is used in dependency. Internally it is using FetchNextNumber. 
        {
            var obj = new TurnNumberSequence();
            return obj.FetchNextNumber();
        }

        public int FetchNextNumber()
        {
            return NumberSequenceInstance.GetNextTurnNumber();
        }
    }

}
