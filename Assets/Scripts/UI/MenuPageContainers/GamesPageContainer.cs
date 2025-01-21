using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;

namespace Chris
{
    public class GamesPageContainer : PageContainer
    {
        VisualElement m_GameOneContainer; // The game buttons for type one game
        VisualElement m_GameTwoContainer; // The game buttons for type one game

        Button m_GameOneOneButton;
        Button m_GameOneTwoButton;
        Button m_GameTwoOneButton;
        Button m_GameTwoTwoButton;

        List<Button> m_GameOneButtons;

        public GamesPageContainer(VisualElement root): base(root)
        {
            // game type container
            m_GameOneContainer = m_Root.Q<VisualElement>("menu__game-one-container");	
            m_GameTwoContainer = m_Root.Q<VisualElement>("menu__game-two-container");

            // menu__game-<type>-<number>-button
            m_GameOneOneButton = m_GameOneContainer.Q<Button>("menu__game-one-one-button"); 
			m_GameOneTwoButton = m_GameOneContainer.Q<Button>("menu__game-one-two-button");

			m_GameTwoOneButton = m_GameTwoContainer.Q<Button>("menu__game-two-one-button");
			m_GameTwoTwoButton = m_GameTwoContainer.Q<Button>("menu__game-two-two-button");

            // Register callbacks for the buttons
            m_GameOneOneButton.RegisterCallback<ClickEvent>(OnGameOneOneClicked);
            m_GameOneTwoButton.RegisterCallback<ClickEvent>(OnGameOneTwoClicked);

            m_GameTwoOneButton.RegisterCallback<ClickEvent>(OnGameTwoOneClicked);
            m_GameTwoTwoButton.RegisterCallback<ClickEvent>(OnGameTwoTwoClicked);


            // For test, will change to set the button's callback automatically
            m_GameOneButtons = m_GameOneContainer.Query<Button>(className: "game-button").ToList();
            foreach (var b in m_GameOneButtons)
            {
                Debug.Log(b.name); // e.g. menu__game-one-one-button
            }
        }

        private void OnGameOneOneClicked(ClickEvent evt)
        {
            UIEvents.DescriptionScreenShow?.Invoke();
            DescriptionEvents.DescriptionChanged?.Invoke(GameType.Type1, 0); // Should be a better way, not hard coded
		}

        private void OnGameOneTwoClicked(ClickEvent evt)
        {
            UIEvents.DescriptionScreenShow?.Invoke();
            DescriptionEvents.DescriptionChanged?.Invoke(GameType.Type1, 1); // Should be a better way, not hard coded
		}

        private void OnGameTwoOneClicked(ClickEvent evt)
        {
            UIEvents.DescriptionScreenShow?.Invoke();
            DescriptionEvents.DescriptionChanged?.Invoke(GameType.Type2, 0);
		}
        
        private void OnGameTwoTwoClicked(ClickEvent evt)
        {
            UIEvents.DescriptionScreenShow?.Invoke();
            DescriptionEvents.DescriptionChanged?.Invoke(GameType.Type2, 1);
		}
    }
}
