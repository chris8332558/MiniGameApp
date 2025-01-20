using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;

public class MainMenuController : MonoBehaviour
{
    public VisualElement ui;

    public Button startButton;
    public Button resumeButton;
    public Button quitButton;

    private void Awake()
    {
        ui = GetComponent<UIDocument>().rootVisualElement;
    }

    private void Start()
    {
        startButton = ui.Q<Button>("StartButton");
        startButton.clicked += OnStartButtonClicked;

        resumeButton = ui.Q<Button>("ResumeButton");
        resumeButton.clicked += OnResumeButtonClicked;

        quitButton = ui.Q<Button>("QuitButton");
        quitButton.clicked += OnQuitButtonClicked;
    }

    private void OnStartButtonClicked()
    {
        gameObject.SetActive(false);
	}

    private void OnResumeButtonClicked()
    {
        Debug.Log("Resume");
	}

    private void OnQuitButtonClicked()
    {
        Application.Quit();
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
    }
}

