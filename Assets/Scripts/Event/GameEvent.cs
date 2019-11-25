using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameEvent : ScriptableObject
{
    private readonly List<GameEventListener> _listeners = new List<GameEventListener>();

    public void Raise()
    {
        for (var listenerIndex = _listeners.Count - 1; listenerIndex >= 0; listenerIndex--)
        {
            _listeners[listenerIndex].OnEventRaised();
        }
    }

    public void RegisterListener(GameEventListener listener)
    {
        if (!_listeners.Contains(listener)) _listeners.Add(listener);
    }

    public void UnregisterListener(GameEventListener listener)
    {
        if (_listeners.Contains(listener)) _listeners.Remove(listener);
    }
}