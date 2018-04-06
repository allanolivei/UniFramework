using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameEvent : ScriptableObject
{
    public bool printInvokeMessage;

    /// <summary>
    /// The list of listeners that this event will notify if it is invoked.
    /// </summary>
    private readonly List<GameEventListener> eventListeners =
        new List<GameEventListener>();

    /// <summary>
    /// The list of listeners that this event will notify if it is invoked.
    /// </summary>
    private readonly List<Action> actions = new List<Action>();

#if ODIN_INSPECTOR
    private string GetButtonName { get { return "Invoke " + this.name; } }

    [Sirenix.OdinInspector.Button("$GetButtonName", Sirenix.OdinInspector.ButtonSizes.Medium)]
#endif
    public void Invoke()
    {
        InvokeEvent("an unknown caller");
    }

    public void Invoke(string caller)
    {
        InvokeEvent(caller);
    }

    private void InvokeEvent(string caller)
    {
        if (printInvokeMessage)
            SmartDebug.Log($"{name} was invoked by {caller} at {Time.realtimeSinceStartup} seconds.");

        for (int i = actions.Count - 1; i >= 0; i--)
            actions[i].Invoke();

        for (int i = eventListeners.Count - 1; i >= 0; i--)
            eventListeners[i].OnEventRaised();
    }

    public void AddListener(GameEventListener listener)
    {
        if (!eventListeners.Contains(listener))
            eventListeners.Add(listener);
    }

    public void RemoveListener(GameEventListener listener)
    {
        if (eventListeners.Contains(listener))
            eventListeners.Remove(listener);
    }

    public void AddListener(Action action)
    {
        if (!actions.Contains(action))
            actions.Add(action);
    }

    public void RemoveListener(Action action)
    {
        if (actions.Contains(action))
            actions.Remove(action);
    }
}