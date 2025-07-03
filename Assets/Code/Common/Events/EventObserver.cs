using Assets.Code.Common.Events;

public interface EventObserver
{
    void Process(EventData eventData);
}
