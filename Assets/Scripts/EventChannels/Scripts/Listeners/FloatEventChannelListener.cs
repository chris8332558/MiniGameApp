using UnityEngine;
using UnityEngine.Events;

namespace Chris
{
    public class FloatEventChannelListener : MonoBehaviour
    {
        [SerializeField] private FloatEventChannelSO mEventChannel;
        [SerializeField] private UnityEvent<float> mResponse;

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

        public void OnEventInvoked(float value)
        {
            mResponse.Invoke(value);
		}
    }
}
