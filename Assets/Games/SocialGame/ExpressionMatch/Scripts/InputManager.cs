using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [HideInInspector] public InputAction swipeUpAction;
    [HideInInspector] public InputAction swipeDownAction;
    [HideInInspector] public InputAction swipeLeftAction;
    [HideInInspector] public InputAction swipeRightAction;

    private void Start()
    {
        swipeUpAction = InputSystem.actions.FindAction("SwipeUp"); // Find in project-wide actions
        swipeDownAction = InputSystem.actions.FindAction("SwipeDown"); // Find in project-wide actions
        swipeLeftAction = InputSystem.actions.FindAction("SwipeLeft"); // Find in project-wide actions
        swipeRightAction = InputSystem.actions.FindAction("SwipeRight"); // Find in project-wide actions
    }

}
