using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;

namespace Chris
{
    public class GamesPageContainer : PageContainer
    {
        VisualElement m_GameOneContainer; // The game buttons for type one game
        VisualElement m_GameTwoContainer; // The game buttons for type one game

        Button m_TypeOneGameOneButton;
        Button m_TypeTwoGameOneButton;

        List<Button> m_GameOneButtons;

        public GamesPageContainer(VisualElement root): base(root)
        {
            // game type container
            m_GameOneContainer = m_Root.Q<VisualElement>("menu__game-one-container");	
            m_GameTwoContainer = m_Root.Q<VisualElement>("menu__game-two-container");

            // menu__game-<type>-<number>-button
            m_TypeOneGameOneButton = m_GameOneContainer.Q<Button>("menu__game-one-one-button");
            m_TypeTwoGameOneButton = m_GameTwoContainer.Q<Button>("menu__game-two-one-button");

            // For test
            m_GameOneButtons = m_GameOneContainer.Query<Button>(className: "game-button").ToList();
            foreach (var b in m_GameOneButtons)
            {
                Debug.Log(b.name); // e.g. menu__game-one-one-button
            }

            m_TypeOneGameOneButton.RegisterCallback<ClickEvent>(OnGameOneStart);
            m_TypeTwoGameOneButton.RegisterCallback<ClickEvent>(OnGameTwoStart);
        }

        private void OnGameOneStart(ClickEvent evt)
        {
            Debug.Log("Type 1 Game 1 start");
            UIEvents.GameScreenShow?.Invoke();
            SceneEvents.LoadSceneByIndex?.Invoke(1);
		}

        private void OnGameTwoStart(ClickEvent evt)
        { 
            Debug.Log("Type 2 Game 1 start");
            UIEvents.GameScreenShow?.Invoke();
            SceneEvents.LoadSceneByIndex?.Invoke(2);
		}
    }
}
