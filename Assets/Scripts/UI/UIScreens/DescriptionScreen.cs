using UnityEngine;
using UnityEngine.UIElements;

namespace Chris
{
    public class DescriptionScreen : UIScreen 
    {
        Label m_GameTitle;
        Label m_Description;
        Button m_CloseButton;
        Button m_StartButton;
        int m_GameSceneIndex;

        public DescriptionScreen(VisualElement root, bool isTransparent = false): base(root, isTransparent)
        {
            m_GameTitle = root.Q<Label>("description__game-title"); 
            m_Description = root.Q<Label>("description__game-description");
            m_CloseButton = root.Q<Button>("description__close-button");
            m_StartButton = root.Q<Button>("description__start-button");

            // Set the title and the description
            DescriptionEvents.GameTitleSet += OnGameTitleSet;
            DescriptionEvents.DescriptionSet += OnDescriptionSet;
            DescriptionEvents.GameSceneIdxSet += OnGameSceneIdxSet;

            // Register callbacks
            m_CloseButton.RegisterCallback<ClickEvent>(OnCloseButtonClicked);
            m_StartButton.RegisterCallback<ClickEvent>(OnStartButtonClicked);

		}

        private void OnCloseButtonClicked(ClickEvent e)
        {
            UIEvents.CloseScreen?.Invoke();
		}

        private void OnStartButtonClicked(ClickEvent e)
        {
            UIEvents.CloseScreen?.Invoke(); // Close the Descrription screen first
            UIEvents.GameScreenShow?.Invoke();
            Debug.Log("Start Game: " + m_GameSceneIndex);
            SceneEvents.LoadSceneByIndex?.Invoke(m_GameSceneIndex);
		}

        private void OnGameTitleSet(string title)
        {
            m_GameTitle.text = title;
		}

        private void OnDescriptionSet(string description)
        {
            m_Description.text = description; 
		}

        private void OnGameSceneIdxSet(int idx)
        {
            m_GameSceneIndex = idx;
		}
    }
}
