using UnityEngine;
using UnityEngine.UIElements;

namespace Chris
{
    public class GameScreen : UIScreen 
    {
        Button m_BackButton;
        Label m_GameplayTimeText;
        Label m_ScoreText;

        float m_InitGameplayTime = 2 * 60 + 30; // Time in seconds (2:30 in this case)
        int m_InitScore = 0;

        public GameScreen(VisualElement root, bool isTransparent = false): base(root, isTransparent)
        {
            m_BackButton = root.Q<Button>("game__back-button");
            m_GameplayTimeText = root.Q<Label>("game__gameplay-time-text");
            m_ScoreText = root.Q<Label>("game__score-text");

            m_GameplayTimeText.text = FormatTime(m_InitGameplayTime);
            m_ScoreText.text = FormatScore(m_InitScore);
            m_BackButton.RegisterCallback<ClickEvent>(OnBackButtonClicked);
		}

        private void OnBackButtonClicked(ClickEvent evt)
        {
            SceneEvents.UnloadLastScene?.Invoke();
            UIEvents.CloseScreen(); // Close GameScreen
		}

        private string FormatTime(float time)
        {
            int minutes = (int)time / 60;
            int seconds = (int)time - 60 * minutes;
            return string.Format("{0:00}:{1:00}", minutes, seconds);
            //int milliseconds = (int)(1000 * (time - minutes * 60 - seconds));
            //return string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
        }

        private string FormatScore(float score)
        {
            return string.Format("{000000}", score);
		}
    }
}
