using UnityEngine;
using UnityEngine.UIElements;

namespace Chris
{
    public enum MenuPage
    { 
	    Home, Games, Stats, Insights, More
	}

    public class MenuScreen : UIScreen 
    {
        Button m_HomeButton;
        Button m_GamesButton;
        Button m_StatsButton;
        Button m_InsightsButton;
        Button m_MoreButton;
        Button m_SettingButton;

        // The tabs
        PageContainer m_CurrentPageContainer;
        PageContainer m_HomePageContainer;
        PageContainer m_GamesPageContainer;
        PageContainer m_StatsPageContainer;
        PageContainer m_InsightsPageContainer;
        PageContainer m_MorePageContainer;

        public MenuScreen(VisualElement root, bool isTransparent = false): base(root, isTransparent)
        {
            SetUpElements();
            RegisterCallbacks();
            HideAllPages();

            // Show the Home page at start
            ShowPage(MenuPage.Home);
		}

        private void SetUpElements()
        { 
            // Buttons
            m_HomeButton = m_RootElement.Q<Button>("menu__home-button");
            m_GamesButton = m_RootElement.Q<Button>("menu__games-button");
            m_StatsButton = m_RootElement.Q<Button>("menu__stats-button");
            m_InsightsButton = m_RootElement.Q<Button>("menu__insights-button");
            m_MoreButton = m_RootElement.Q<Button>("menu__more-button");
            m_SettingButton = m_RootElement.Q<Button>("menu__setting-button");

            // Page containers
            m_HomePageContainer = new HomePageContainer(m_RootElement.Q<VisualElement>("menu__home-page-container"));
            m_GamesPageContainer = new GamesPageContainer(m_RootElement.Q<VisualElement>("menu__games-page-container"));
            m_StatsPageContainer = new StatsPageContainer(m_RootElement.Q<VisualElement>("menu__stats-page-container"));
            m_InsightsPageContainer = new InsightsPageContainer(m_RootElement.Q<VisualElement>("menu__insights-page-container"));
            m_MorePageContainer = new MorePageContainer(m_RootElement.Q<VisualElement>("menu__more-page-container"));
        }

        private void RegisterCallbacks()
        { 
            m_HomeButton.RegisterCallback<ClickEvent>(OnHomeButtonClicked);
            m_GamesButton.RegisterCallback<ClickEvent>(OnGamesButtonClicked);
            m_StatsButton.RegisterCallback<ClickEvent>(OnStatsButtonClicked);
            m_InsightsButton.RegisterCallback<ClickEvent>(OnInsightsButtonClicked);
            m_MoreButton.RegisterCallback<ClickEvent>(OnMoreButtonClicked);
            m_SettingButton.RegisterCallback<ClickEvent>(OnSettingButtonClicked);
		}

        private void ShowPage(MenuPage page)
        {
            if (m_CurrentPageContainer != null)
                m_CurrentPageContainer.Hide();
            switch (page)
            {
                case MenuPage.Home:
                    m_HomePageContainer.Show();
                    m_CurrentPageContainer = m_HomePageContainer;
                    break;
                case MenuPage.Games:
                    m_GamesPageContainer.Show();
                    m_CurrentPageContainer = m_GamesPageContainer;
                    break;
                case MenuPage.Stats:
                    m_StatsPageContainer.Show();
                    m_CurrentPageContainer = m_StatsPageContainer;
                    break;
                case MenuPage.Insights:
                    m_InsightsPageContainer.Show();
                    m_CurrentPageContainer = m_InsightsPageContainer;
                    break;
                case MenuPage.More:
                    m_MorePageContainer.Show();
                    m_CurrentPageContainer = m_MorePageContainer;
                    break;
			}
		}

        private void HideAllPages()
        {
            m_HomePageContainer.Hide();
            m_GamesPageContainer.Hide(); 
            m_StatsPageContainer.Hide(); 
            m_InsightsPageContainer.Hide();
            m_MorePageContainer.Hide();
		}

        private void OnHomeButtonClicked(ClickEvent evt)
        {
            Debug.Log("Home Button Clicked");
            ShowPage(MenuPage.Home);
		}

        private void OnGamesButtonClicked(ClickEvent evt)
        { 
            Debug.Log("Games Button Clicked");
            ShowPage(MenuPage.Games);
		}

        private void OnStatsButtonClicked(ClickEvent evt)
        { 
            Debug.Log("Stats Button Clicked");
            ShowPage(MenuPage.Stats);
		}

        private void OnInsightsButtonClicked(ClickEvent evt)
        { 
            Debug.Log("Insights Button Clicked");
            ShowPage(MenuPage.Insights);
		}

        private void OnMoreButtonClicked(ClickEvent evt)
        { 
            Debug.Log("More Button Clicked");
            ShowPage(MenuPage.More);
		}

        private void OnSettingButtonClicked(ClickEvent evt)
        { 
            Debug.Log("Setting Button Clicked");
            UIEvents.SettingScreenShow?.Invoke();
		}
    }
}
