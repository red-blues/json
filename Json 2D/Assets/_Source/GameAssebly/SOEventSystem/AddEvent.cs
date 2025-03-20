using UnityEngine;

#region Add Event
public interface IAddEventListener : IGameEventListener<int> { }
[CreateAssetMenu(fileName = "AddEvent", menuName = "SO/New Custom Event/Add Event")]
public class AddEvent : ACustomEventSO<IAddEventListener, int> { }
public class AddMenuState : /*AState,*/ IAddEventListener
{
    //private ResourcePool _resourcePool;
    private AddEvent _addEvent;

    public void Enter()
    {
        _addEvent.AddListener(this);
    }

    public void Notify(int value)
    {
        //_resourcePool.Add(value);
    }

    public void Exit()
    {
        _addEvent.RemoveListener(this);
    }
}
#endregion