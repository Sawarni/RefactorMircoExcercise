namespace TDDMicroExercises.TurnTicketDispenser.Interfaces
{
    /// <summary>
    /// Interface to expose Ticket Dispenser function to future clients.
    /// </summary>
    public interface ITicketDispenser
    {
        ITurnTicket GetTurnTicket();
    }
}