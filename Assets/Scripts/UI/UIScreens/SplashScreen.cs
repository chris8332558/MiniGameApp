using UnityEngine;
using UnityEngine.UIElements;

namespace Chris
{
    public class SplashScreen : UIScreen
    {
        ProgressBar m_ProgressBar;

        public SplashScreen(VisualElement rootElement, bool isTransparent = false) : base(rootElement, isTransparent)
        {
            m_ProgressBar = m_RootElement.Q<ProgressBar>("splash__progress-bar");
            SceneEvents.LoadProgressUpdated += OnLoadProgressUpdated;
            SceneEvents.LoadCompleted += OnLoadCompleted;
        }

        public void OnLoadProgressUpdated(float value)
        {
            if (m_ProgressBar == null)
                return;

            m_ProgressBar.value = value;
        }

        public void OnLoadCompleted()
        {
            //Hide();
        }
    }
}
