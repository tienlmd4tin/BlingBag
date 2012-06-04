using DomainEvents.SampleConsoleApp.FakeDomainLayer.Events;

namespace DomainEvents.SampleConsoleApp.FakeDomainLayer.EventHandlers
{
    public class EmailTheAccountHolderAfterNameChanged : IDomainEventHandler<TheNameChanged>
    {
        readonly IEmailClient _emailClient;

        public EmailTheAccountHolderAfterNameChanged(IEmailClient emailClient)
        {
            _emailClient = emailClient;
        }

        public void Handle(TheNameChanged @event)
        {
            _emailClient.Send(@event.Account.EmailAddress, "Name Changed",
                              string.Format("Your name has been changed from {0} to {1}.", @event.OldName,
                                            @event.NewName));
        }
    }
}