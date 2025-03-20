using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameEventListener 
{ void Notify(); }
public interface IGameEventListener<U> 
{ void Notify(U value); }
public interface IGameEventListener<U, U1> 
{ void Notify(U value, U1 value1);}
public abstract class ACustomEventSO<T> : ScriptableObject where T : IGameEventListener
{
    private List<T> _observers = new();
    public void AddListener(T observer) => _observers.Add(observer);
    public void RemoveListener(T observer) => _observers.Remove(observer);

    public void Notify()
    {
        foreach (T observer in _observers)
        {
            observer.Notify();
        }
    }
}

public abstract class ACustomEventSO<T, U> 
    : ScriptableObject 
    where T : IGameEventListener<U>
{
    private List<T> _observers = new();
    public void AddListener(T observer) => 
        _observers.Add(observer);
    public void RemoveListener(T observer) => 
        _observers.Remove(observer);

    public void Notify(U value)
    {
        foreach (T observer in _observers)
        {
            observer.Notify(value);
        }
    }
}
#region Reset Event
public interface IResetEventListener : IGameEventListener { }
[CreateAssetMenu(fileName = "ResetEvent", menuName = "SO/New Custom Event/Reset Event")]
public class ResetEvent : ACustomEventSO<IResetEventListener> { }

public class MainMenuState : /*AState,*/ IResetEventListener
{
    //private ResourcePool _resourcePool;
    private ResetEvent _resetEvent;

    public void Enter()
    {
        _resetEvent.AddListener(this);
    }

    public void Notify()
    {
        //_resourcePool.Reset();
    }

    public void Exit()
    {
        _resetEvent.RemoveListener(this);
    }
}
#endregion

#region Add Event
/*
public interface IAddEventListener : IGameEventListener<int> { }
[CreateAssetMenu(fileName = "AddEvent", menuName = "SO/New Custom Event/Add Event")]
public class AddEvent : ACustomEventSO<IAddEventListener, int> { }
public class AddMenuState : *//*AState,*//* IAddEventListener
{
    //private ResourcePool _resourcePool;
    private AddEvent _resetEvent;

    public void Enter()
    {
        _resetEvent.AddListener(this);
    }

    public void Notify(int value)
    {
        //_resourcePool.Add(value);
    }

    public void Exit()
    {
        _resetEvent.RemoveListener(this);
    }
}*/
#endregion