using UnityEngine;

namespace Chris
{
    public class GamePresenter : MonoBehaviour
    {
        // Currently not using this, handled the time in GameScreen.cs now
        float m_CurrentGameplayTime;

        private void OnEnable()
        {
            GameEvents.GameplayTimeChanged += OnGameplayTimeChanged;
        }

        private void OnGameplayTimeChanged(float time)
        {
            GameEvents.GameplayTimeSet?.Invoke(m_CurrentGameplayTime); // Set GameScreen
        }
    }
}
