using UnityEngine;
using UnityEngine.Events;

namespace Chris
{
    public class IntEventChannelListener : MonoBehaviour
    {
        [SerializeField] private IntEventChannelSO mEventChannel;
        [SerializeField] private UnityEvent mResponse;

        private void OnEnable()
        {
            if (mEventChannel != null)
                mEventChannel.Event += OnEventInvoked;
        }

        private void OnDisable()
        {
            if (mEventChannel != null)
                mEventChannel.Event -= OnEventInvoked;
        }

        public void OnEventInvoked(int value)
        {
            mResponse.Invoke();
		}
    }
}
