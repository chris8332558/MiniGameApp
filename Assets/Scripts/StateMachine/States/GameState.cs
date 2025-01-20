using UnityEngine;

namespace Chris
{
    public class GameState : State
    {
        
        public override void Enter()
        {
            Debug.Log("Enter Game State");
		}

        public override void Update()
        {
        }

        public override void Exit()
        {
            Debug.Log("Exit Game State");
        }
    }
}
