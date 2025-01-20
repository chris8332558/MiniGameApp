using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;

namespace Chris
{
    public class StartState : State
    {
        public override void Enter()
        {
            Debug.Log("Enter StartState, show start screen");
            UIEvents.StartScreenShow.Invoke();
        }

        public override void Update()
        {
        }

        public override void Exit()
        {
            Debug.Log("Exit StartState, show menu screen");
        }
    }
}
