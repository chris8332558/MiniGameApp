using UnityEngine;
using UnityEngine.Events;

namespace Chris
{
    [CreateAssetMenu(fileName = "VoidEventChannel", menuName = "EventChannels/Void")]
    public class VoidEventChannelSO : ScriptableObject
    {
        public UnityAction Event;

        public void InvokeEvent()
        {
            if (Event == null)
                return;

            Event.Invoke();
        }
    }
}
