using UnityEngine;

namespace Chris
{
    public class SettingState : State
    {
        public override void Enter()
        {
            Debug.Log("Enter SettingState");
        }

        public override void Update()
        {

        }

        public override void Exit()
        {
            Debug.Log("Eixt SettingState");
        }
    }
}
