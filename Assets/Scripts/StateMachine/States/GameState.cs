using UnityEngine;
using System;
using System.Collections;

namespace Chris
{
    public class GameState : State
    {
        float m_CountdownTime = 3f;
        bool m_GameStartedInvoked;

        public override void Enter()
        {
            m_CountdownTime = 3.5f;
            m_GameStartedInvoked = false;
            SceneEvents.GameStartCountdownStarted?.Invoke();
            Debug.Log("Enter Game State");
		}

        public override void Update()
        {
            if (m_CountdownTime > 0)
            {
                m_CountdownTime -= Time.deltaTime;
                SceneEvents.GameStartCountdownTextUpdated?.Invoke(m_CountdownTime.ToString("0"));
            }
            else if (!m_GameStartedInvoked)
            {
                SceneEvents.GameStartCountdownCompleted?.Invoke();
                GameEvents.GameStarted?.Invoke();
                m_GameStartedInvoked = true;
            }
        }

        public override void Exit()
        {
            Debug.Log("Exit Game State");
        }
    }
}
