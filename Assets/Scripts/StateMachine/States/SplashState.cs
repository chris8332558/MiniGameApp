using UnityEngine;
using System.Collections.Generic;

namespace Chris
{
    public class SplashState : State
    {
        float m_ProgressValue;
        float m_LoadingTime = 1f; // Need to depend on real loading time
        float m_StartTime;

        public override void Enter()
        {
            Debug.Log("Enter SplashState");
            UIEvents.SpalishScreenShow?.Invoke();
            m_ProgressValue = 0f;
            m_StartTime = Time.time;
        }

        public override void Update()
        {
            m_ProgressValue = (Time.time - m_StartTime) / m_LoadingTime;
            if (m_ProgressValue >= 1)
            {
                EnableLinks();
			}
            SceneEvents.LoadProgressUpdated?.Invoke(m_ProgressValue);
        }

        public override void Exit()
        {
            Debug.Log("Load Completed, eixt SplashState");
            SceneEvents.LoadCompleted?.Invoke();
        }

    }
}
