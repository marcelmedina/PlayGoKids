using MediatR;

namespace CQRSAndMediatrSampleApplication.Product.Notify
{
    public class PublishProductNotify : INotification
    {
        public string Message { get; set; }
    }

    public class PublishProductNotifyMessageHandler : INotificationHandler<PublishProductNotify>
    {
        public Task Handle(PublishProductNotify notification, CancellationToken cancellationToken)
        {
            //TODO: Send message
            Console.WriteLine($"Message: {notification.Message}");
            return Task.CompletedTask;
        }
    }

    public class PublishProductNotifyTextHandler : INotificationHandler<PublishProductNotify>
    {
        public Task Handle(PublishProductNotify notification, CancellationToken cancellationToken)
        {
            //TODO: Send text
            Console.WriteLine($"Text: {notification.Message}");
            return Task.CompletedTask;
        }
    }
}
