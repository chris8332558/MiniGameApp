using UnityEngine;
using System;
using System.Collections;


namespace Chris
{
    public class GameState : State
    {
        float m_CoundownTime = 3f;

        public override void Enter()
        {
            m_CoundownTime = 3f;
            SceneEvents.GameStartCountdownStarted?.Invoke();
            Debug.Log("Enter Game State");
		}

        public override void Update()
        {
            if (m_CoundownTime >= 0)
            {
                m_CoundownTime -= Time.deltaTime;
                SceneEvents.GameStartCountdownTextUpdated?.Invoke(m_CoundownTime.ToString("0"));
            }
            else
            {
                SceneEvents.GameStartCountdownCompleted?.Invoke();
                GameEvents.GameStarted?.Invoke();
            }
        }

        public override void Exit()
        {
            Debug.Log("Exit Game State");
        }
    }
}
