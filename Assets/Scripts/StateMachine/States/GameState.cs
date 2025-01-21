using UnityEngine;

namespace Chris
{
    public class GameState : State
    {
        private float m_CurrentGameplayTime;  

        public override void Enter()
        {
            Debug.Log("Enter Game State");
            GameEvents.GameStarted?.Invoke();
		}

        public override void Update()
        {
        }

        public override void Exit()
        {
            Debug.Log("Exit Game State");
            GameEvents.GameEnded?.Invoke();
        }

        private void OnGameplayTimeSet()
        { 
		}
    }
}
