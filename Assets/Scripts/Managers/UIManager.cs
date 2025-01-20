using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;

namespace Chris
{
    /// <summary>
    /// Using stack to manage UI Screens (uxml files), linten to UIEvents to turn screens on and off.
    /// Note: Set screens in the uxml to be (Pos:absolute; Size:100%, 100%; Picking mode: Ignore)
    /// </summary>
    public class UIManager : MonoBehaviour
    {
        public UIScreen CurrentScreen => m_CurrentScreen;
        public UIDocument Document => m_Document;

        UIDocument m_Document; // The document contains all the uxml files
        UIScreen m_CurrentScreen;

        UIScreen m_SplashScreen;
        UIScreen m_StartScreen;
        UIScreen m_MenuScreen;
        UIScreen m_SettingScreen;
        UIScreen m_DescriptionScreen;
        UIScreen m_GameScreen;

        Stack<UIScreen> m_ScreenStack = new();
        List<UIScreen> m_ScreenList = new();

        private void Awake()
        {
            Debug.Log("UIManager::Awake()");
        }

        private void Start()
        {
            Debug.Log("UIManager::Start()");
        }

        private void OnEnable()
        {
            m_Document = GetComponent<UIDocument>();
            SetUpScreens();
            RegisterToEvents();
            Debug.Log("UIManager::OnEnable()");
        }

        private void OnDisable()
        {
            Debug.Log("UIManager::OnDisable()");
            UnregisterToEvents();
        }

        private void OnDestroy()
        {
            Debug.Log("UIManager::OnDestroy()");
        }
 
        private void SetUpScreens()
        {
            VisualElement root = m_Document.rootVisualElement;

            m_SplashScreen = new SplashScreen(root.Q<VisualElement>("splash__container"));
            m_StartScreen = new StartScreen(root.Q<VisualElement>("start__container"));
            m_MenuScreen = new MenuScreen(root.Q<VisualElement>("menu__container"));
            m_SettingScreen = new SettingScreen(root.Q<VisualElement>("setting__container"), true); // is transcript
            m_DescriptionScreen = new DescriptionScreen(root.Q<VisualElement>("description__container"), true); // is transcript
            m_GameScreen = new GameScreen(root.Q<VisualElement>("game__container"));

            AddScreensToList();
            HideScreens();
        }

        private void RegisterToEvents()
        {
            UIEvents.SpalishScreenShow += OnSplashScreenShow;
            UIEvents.StartScreenShow += OnStartScreenShow;
            UIEvents.MenuScreenShow += OnMenuScreenShow;
            UIEvents.SettingScreenShow += OnSettingScreenShow;
            UIEvents.DescriptionScreenShow += OnDescriptionScreenShow;
            UIEvents.GameScreenShow += OnGameScreenShow;
            UIEvents.CloseScreen += OnCloseScreen;
        }

        private void UnregisterToEvents()
        { 
            UIEvents.SpalishScreenShow -= OnSplashScreenShow;
            UIEvents.StartScreenShow -= OnStartScreenShow;
            UIEvents.MenuScreenShow -= OnMenuScreenShow;
            UIEvents.SettingScreenShow -= OnSettingScreenShow;
            UIEvents.DescriptionScreenShow -= OnDescriptionScreenShow;
            UIEvents.GameScreenShow -= OnGameScreenShow;
            UIEvents.CloseScreen -= OnCloseScreen;
		}

        private void AddScreensToList()
        {
            m_ScreenList.Add(m_SplashScreen);
            m_ScreenList.Add(m_StartScreen);
            m_ScreenList.Add(m_MenuScreen);
            m_ScreenList.Add(m_SettingScreen);
            m_ScreenList.Add(m_DescriptionScreen);
            m_ScreenList.Add(m_GameScreen);
        }

        private void HideScreens()
        {
            m_ScreenStack.Clear();
            foreach (var screen in m_ScreenList)
            {
                screen.Hide();
            }
        }

        private void ShowScreen(UIScreen screen, bool pushToStack)
        {
            if (screen == null)
                return;

            if (m_CurrentScreen != null)
            {
                if (!screen.IsTransparent) // e.g. Don't hide the current screen when showing pause screen
                    m_CurrentScreen.Hide();
                if (pushToStack)
                    m_ScreenStack.Push(screen);
            }

            screen.Show();
            m_CurrentScreen = screen;
            Debug.Log("Show a Screen, Stack: " + GetScreenStackStr());
        }

        private void CloseCurrentScreen()
        {
            if (m_ScreenStack.Count == 0)
                return;

            UIScreen screenToClose = m_ScreenStack.Pop();
            screenToClose.Hide();
            m_CurrentScreen = m_ScreenStack.Peek();
            m_CurrentScreen.Show();
            Debug.Log("Close a Screen, Stack: " + GetScreenStackStr());
		}


        // Show Screen callbacks
        public void OnSplashScreenShow()
        {
            // Show StartScreen but don't keep it in the ScreenStack 
            ShowScreen(m_SplashScreen, false);
        }

        public void OnStartScreenShow()
        {
            // Show StartScreen but don't keep it in the ScreenStack 
            ShowScreen(m_StartScreen, false);
        }

        public void OnMenuScreenShow()
        { 
            ShowScreen(m_MenuScreen, true);
		}

        public void OnSettingScreenShow()
        { 
            ShowScreen(m_SettingScreen, true);
		}

        public void OnDescriptionScreenShow()
        { 
            ShowScreen(m_DescriptionScreen, true);
		}

        public void OnGameScreenShow()
        { 
            ShowScreen(m_GameScreen, true);
		}

        public void OnCloseScreen()
        {
            CloseCurrentScreen();
		}

        // For debug
        public string GetScreenStackStr()
        {
            string log = "";
		    foreach (var screen in m_ScreenStack)
            {
                log += screen.GetScreenName() + ", ";
			}
            return log;
		}
    }
}
