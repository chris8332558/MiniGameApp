using UnityEngine;
using System;
using System.Collections;


namespace Chris
{
    public class GameState : State
    {
        bool isGameStarted;

        public override void Enter()
        {
            Debug.Log("Enter Game State");
            GameEvents.GameStarted?.Invoke();
		}

        public override void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) isGameStarted = true; // Will change to wait 3 seconds
            if (isGameStarted)
            {
                GameEvents.GameplayTimeTicked?.Invoke(Time.deltaTime);
            }

        }

        public override void Exit()
        {
            GameEvents.GameEnded?.Invoke();
            Debug.Log("Exit Game State");
        }
    }
}
