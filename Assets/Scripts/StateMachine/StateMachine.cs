using UnityEngine;

namespace Chris
{
    public class StateMachine
    {
        State m_CurrentState;
        StateManager m_StateManager;

        public StateMachine(StateManager manager)
        {
            m_StateManager = manager;	
		}

        public void InitState(State state)
        {
            m_CurrentState = state;
            m_CurrentState.Enter();
        }

        public void Update()
        {
            m_CurrentState.Update();
            CheckLinks();
        }

        public void TransitionTo(State nextState)
        {
            if (nextState == null)
                return;
            Debug.Log("Tansition to: " + nextState.GetType());
            m_CurrentState.Exit();
            m_CurrentState.DisableLinks();
            m_CurrentState = nextState;
            m_CurrentState.Enter();
        }

        private void CheckLinks()
        { 
            if (m_CurrentState.ValidateLinks(out var nextState))
            {
                TransitionTo(nextState);
			}
		}
    }
}
