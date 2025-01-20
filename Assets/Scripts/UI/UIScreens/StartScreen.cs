using UnityEngine;
using UnityEngine.UIElements;

namespace Chris
{
    public class StartScreen : UIScreen
    {
        Button m_StartButton;

        public StartScreen(VisualElement rootElement, bool isTransparent = false) : base(rootElement, isTransparent)
        {
            m_StartButton = rootElement.Q<Button>("start__start-button");
            m_StartButton.RegisterCallback<ClickEvent>(OnStartButtonClicked);
        }

        private void OnStartButtonClicked(ClickEvent evt)
        {
            UIEvents.MenuScreenShow?.Invoke();
		}

    }
}
