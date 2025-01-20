using UnityEngine;
using UnityEngine.Events;

namespace Chris
{
    public abstract class GenericEventChannelSO<T> : ScriptableObject
    {
        public UnityAction<T> Event;

        public void InvokeEvent(T value)
        {
            if (Event == null)
                return;
            Event.Invoke(value);
        }
    }
}
