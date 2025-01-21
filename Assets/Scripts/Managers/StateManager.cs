using UnityEngine;

namespace Chris
{
    /// <summary>
    /// A SequenceManager controls the overall flow of the application using a state machine
    /// 
    /// Use this class to define how each State will transition to the next. Each state can
    /// transition to the next state when receiving an event or reaching a specific condition by adding Links.
    /// </summary>
    public class StateManager : MonoBehaviour
    {
        [SerializeField] GameObject[] m_PreloadedAssets;
        // [SerializeField] bool m_Debug;

        StateMachine m_StateMachine;

        // States
        SplashState m_SplashScreenState = new();
        StartState m_StartScreenState = new();
        MenuState m_MenuScreenState = new();
        //SettingState m_SettingScreenState = new();
        GameState m_GameState = new();

        private void Awake()
        {
            m_StateMachine = new StateMachine(this);
        }

        private void Start()
        {
            Debug.Log("StateManager::Start()");
            SetUpLinks();
            InstPreloadedAssets();

            // Start from splash screen state
            m_StateMachine.InitState(m_SplashScreenState);
        }

        private void Update()
        {
            m_StateMachine.Update(); 
        }
        
        private void SetUpLinks()
        {
            m_SplashScreenState.AddLink(new Link(m_StartScreenState));
            m_StartScreenState.AddLink(new Link(m_MenuScreenState, ref UIEvents.MenuScreenShow));
            //m_MenuScreenState.AddLink(new Link(m_SettingScreenState, ref UIEvents.SettingScreenShow));
            m_MenuScreenState.AddLink(new Link(m_GameState, ref UIEvents.GameScreenShow));
            //m_SettingScreenState.AddLink(new Link(m_MenuScreenState, ref UIEvents.CloseScreen));
            m_GameState.AddLink(new Link(m_MenuScreenState, ref SceneEvents.UnloadLastScene));
		}

        private void InstPreloadedAssets()
        { 
		    foreach (var asset in m_PreloadedAssets)
            {
                Instantiate(asset);	
			}
		}
    }
}
