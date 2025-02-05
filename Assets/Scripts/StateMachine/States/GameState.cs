using UnityEngine;

namespace Chris
{
    public class GameState : State
    {
        public override void Enter()
        {
            Debug.Log("Enter Game State");
            GameEvents.GameStarted?.Invoke();
		}

        public override void Update()
        {
            GameEvents.GameplayTimeTicked?.Invoke(Time.deltaTime);
        }

        public override void Exit()
        {
            GameEvents.GameEnded?.Invoke();
            Debug.Log("Exit Game State");
        }
    }
}
