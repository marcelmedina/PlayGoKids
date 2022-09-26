namespace DurableFunctionsHumanInteractionPattern.Services
{
    public interface INotifier
    {
        void Notify(string message);
    }

    public class Notifier : INotifier
    {
        public void Notify(string message)
        {
            // TODO: send notification
        }
    }
}
