using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private float initScore;
    [SerializeField] private TMP_Text scoreText; 
    private float currentScore;
    public float CurrentScore { get => currentScore; private set => currentScore = value; }

    private void Start()
    {
        currentScore = initScore;
        scoreText.text = "Score: " + initScore.ToString("000000");
    }

    public void AddScore(float aScore)
    {
        currentScore += aScore;
        scoreText.text = "Score: " + currentScore.ToString("000000");
    }
}
