using UnityEngine;
using UnityEngine.Events;

namespace Chris
{
    public class VoidEventChannelListener : MonoBehaviour
    {
        [SerializeField] private VoidEventChannelSO mEventChannle;
        [SerializeField] private UnityEvent mResponse;

        private void OnEnable()
        {
            if (mEventChannle != null)
                mEventChannle.Event += OnEventInvoked;
        }

        private void OnDisable()
        {
            if (mEventChannle != null)
                mEventChannle.Event -= OnEventInvoked;
        }

        public void OnEventInvoked()
        {
            mResponse.Invoke();
		}
    }
}
