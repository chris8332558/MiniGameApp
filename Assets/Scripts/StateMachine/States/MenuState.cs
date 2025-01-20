using UnityEngine;

namespace Chris
{
    public class MenuState : State
    {
        public override void Enter()
        {
            Debug.Log("Enter MenuState");
            //UIEvents.MenuScreenShow.Invoke(); // Call by the StartButton
        }

        public override void Update()
        {

        }

        public override void Exit()
        {
            Debug.Log("Eixt MenuState");
        }
    }
}
