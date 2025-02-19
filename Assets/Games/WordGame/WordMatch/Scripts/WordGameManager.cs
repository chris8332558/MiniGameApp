using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using Chris;

public class WordGameManager : MonoBehaviour
{
    [System.Serializable]
    public class WordPair
    {
        public string leftWord;
        public string rightWord;
        // Optionally, add more data (e.g. a flag for synonym/antonym) if needed.
    }

    [Header("UI References")]
    public Transform leftColumnContainer;
    public Transform rightColumnContainer;
    public GameObject wordPrefab; // Prefab must include a Text, CanvasGroup, and DraggableWord component.
    public TMP_Text timer; // Prefab must include a Text, CanvasGroup, and DraggableWord component.

    [Header("Game Data")]
    public float timeInSeconds; // Fill these in via the Inspector
    public List<WordPair> wordPairs; // Fill these in via the Inspector

    // Scoring variables
    private int moveCount = 0;
    private int tries = 0;
    private float startTime;

    private bool isGameStarted;

    private void OnEnable()
    {
        GameEvents.GameStarted += OnGameStarted;
    }

    private void OnDisable()
    {
        GameEvents.GameStarted -= OnGameStarted;
    }

    void Start()
    {
        startTime = Time.time;
        isGameStarted = false;
    }

    private void Update()
    {
        if (isGameStarted)
        {
            if (timeInSeconds >= 0)
            {
                timeInSeconds -= Time.deltaTime;
                timer.text = Helper.FormatTime(timeInSeconds);
            }
            else
            {
                SceneEvents.UnloadLastScene?.Invoke(); // Unload this scene
                GameEvents.GameEnded?.Invoke();
                UIEvents.CloseScreen(); // Close GameScreen
            }
        }
    }

    void OnGameStarted()
    {
        isGameStarted = true;
        SetupGame();
	}


    // Called once at the start to create the columns
    void SetupGame()
    {
        // Create separate lists of words for the left and right columns.
        List<string> leftWords = new List<string>();
        List<string> rightWords = new List<string>();

        foreach (WordPair pair in wordPairs)
        {
            leftWords.Add(pair.leftWord);
            rightWords.Add(pair.rightWord);
        }

        // Shuffle the lists independently so that the matching pairs are not initially aligned.
        leftWords = ShuffleList(leftWords);
        rightWords = ShuffleList(rightWords);

        // Instantiate UI elements for the left column.
        foreach (string word in leftWords)
        {
            GameObject go = Instantiate(wordPrefab, leftColumnContainer);
            go.GetComponentInChildren<Text>().text = word;
        }

        // Instantiate UI elements for the right column.
        foreach (string word in rightWords)
        {
            GameObject go = Instantiate(wordPrefab, rightColumnContainer);
            go.GetComponentInChildren<Text>().text = word;
        }
    }

    // Simple list shuffler (Fisher–Yates shuffle)
    List<T> ShuffleList<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            T temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
        return list;
    }

    // Called by DraggableWord when an item is dropped.
    public void IncrementMoveCount()
    {
        moveCount++;
    }

    // This method can be hooked up to a “Check” button.
    public void CheckSolution()
    {
        // Assume both columns have the same number of words.
        int total = leftColumnContainer.childCount;
        int correctMatches = 0;

        for (int i = 0; i < total; i++)
        {
            // Get the words at index i in each column.
            string leftWord = leftColumnContainer.GetChild(i).GetComponentInChildren<Text>().text;
            string rightWord = rightColumnContainer.GetChild(i).GetComponentInChildren<Text>().text;

            // Check if this pair is valid.
            bool matchFound = false;
            foreach (WordPair pair in wordPairs)
            {
                if ((pair.leftWord == leftWord && pair.rightWord == rightWord) ||
                    (pair.leftWord == rightWord && pair.rightWord == leftWord))
                {
                    matchFound = true;
                    break;
                }
            }
            if (matchFound)
            {
                correctMatches++;
            }
        }

        if (correctMatches == total)
        {
            // All pairs are matched correctly!
            float timeTaken = Time.time - startTime;
            int score = CalculateScore(tries, moveCount, timeTaken);
            Debug.Log("Congratulations! You matched all pairs correctly.");
            Debug.Log("Moves: " + moveCount + " | Tries: " + tries + " | Time: " + timeTaken.ToString("F2") + " sec");
            Debug.Log("Your Score: " + score);
        }
        else
        {
            // Not all pairs match—count this as an additional try.
            tries++;
            Debug.Log("Not all matches are correct. Try again!");
        }
    }

    // A sample scoring function: you can adjust the formula as desired.
    int CalculateScore(int tries, int moves, float timeTaken)
    {
        int baseScore = 1000;
        int penalty = tries * 50 + moves * 10 + (int)timeTaken * 5;
        return Mathf.Max(0, baseScore - penalty);
    }
}
