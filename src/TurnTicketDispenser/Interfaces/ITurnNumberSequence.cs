namespace TDDMicroExercises.TurnTicketDispenser.Interfaces
{
    /// <summary>
    /// Interface to expose fucntionality to get next turn number.
    /// </summary>
    public interface ITurnNumberSequence
    {
        int FetchNextNumber();
    }
}