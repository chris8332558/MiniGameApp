using UnityEngine;
using UnityEngine.UIElements;

namespace Chris
{
    public class GameScreen : UIScreen 
    {
        Button m_BackButton;
        Label m_GameplayTimeText;
        Label m_ScoreText;
        Label m_GameStartCountdownText;
        VisualElement m_CountdownBG;

        float m_CurrGameplayTime = 0; // Time in seconds
        int m_InitScore = 0;

        public GameScreen(VisualElement root, bool isTransparent = false): base(root, isTransparent)
        {
            m_BackButton = root.Q<Button>("game__back-button");
            m_GameplayTimeText = root.Q<Label>("game__gameplay-time-text");
            m_ScoreText = root.Q<Label>("game__score-text");
            m_GameStartCountdownText = root.Q<Label>("game__countdown-text");
            m_CountdownBG = root.Q<VisualElement>("game__countdownBG");

            m_GameplayTimeText.text = Helper.FormatTime(0);
            m_ScoreText.text = Helper.FormatScore(m_InitScore);
            m_BackButton.RegisterCallback<ClickEvent>(OnBackButtonClicked);

            SceneEvents.GameStartCountdownTextUpdated += OnCountDownTextUpdated;
            SceneEvents.GameStartCountdownCompleted += OnCountDownCompleted;
            GameEvents.GameplayTimeSet += OnGameplayTimeSet;
            GameEvents.GameplayTimeTicked += OnGameplayTimeTicked;
		}

        private void OnBackButtonClicked(ClickEvent evt)
        {
            SceneEvents.UnloadLastScene?.Invoke();
            UIEvents.CloseScreen(); // Close GameScreen
		}

        private void OnCountDownTextUpdated(string timeString)
        {
            m_GameStartCountdownText.text = timeString;
		}

        private void OnCountDownCompleted()
        {
            m_CountdownBG.style.visibility = Visibility.Hidden;
            m_GameStartCountdownText.style.visibility = Visibility.Hidden;
		}

        private void OnGameplayTimeSet(float time)
        {
            m_CurrGameplayTime = time;
            m_GameplayTimeText.text = Helper.FormatTime(m_CurrGameplayTime);
		}

        private void OnGameplayTimeTicked(float time)
        {
            m_CurrGameplayTime -= time;
            m_GameplayTimeText.text = Helper.FormatTime(m_CurrGameplayTime);
            if (m_CurrGameplayTime <= 0)
            {
                SceneEvents.UnloadLastScene?.Invoke();
                UIEvents.CloseScreen(); // Close GameScreen
            }
        }
    }
}
