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

            // For test, will change to set the button's callback automatically
            m_GameOneButtons = m_GameOneContainer.Query<Button>(className: "game-button").ToList();
            foreach (var b in m_GameOneButtons)
            {
                Debug.Log(b.name); // e.g. menu__game-one-one-button
            }

            m_TypeOneGameOneButton.RegisterCallback<ClickEvent>(OnGameOneOneClicked);
            m_TypeTwoGameOneButton.RegisterCallback<ClickEvent>(OnGameTwoOneClicked);
        }

        private void OnGameOneOneClicked(ClickEvent evt)
        {
            UIEvents.DescriptionScreenShow?.Invoke();
            DescriptionEvents.DescriptionChanged?.Invoke(GameType.Type1, 0); // Should be a better way, not hard coded
		}

        private void OnGameTwoOneClicked(ClickEvent evt)
        {
            UIEvents.DescriptionScreenShow?.Invoke();
            DescriptionEvents.DescriptionChanged?.Invoke(GameType.Type2, 0);
		}
    }
}
