using UnityEngine;
using System.Collections;
using TMPro;
using DG.Tweening;

public class CardHolder : MonoBehaviour
{
    //[SerializeField] private List<Card> cards;
    private Card currentCard;
    private bool isSwipeDone;

    [Header("Move")]
    public float moveDis;
    public float moveDelta;
    public float movePeriod;

    [Header("FadeOut")]
    public float fadeDelta;
    public float fadePeriod;

    public SpriteRenderer resultHint; // For test

    private InputManager inputManager;
    private SpriteRenderer spRenderer;
    private CardProvider cardProvider;
    private BoxCollider2D boxCollider;

    public bool isDragging;
    public Vector3 offset;
    private Vector2 originPos;

    [Header("Score")]
    public ScoreManager scoreManager;
    public float initCardScore;
    public TMP_Text cardScoreText;
    public float subScoreTime;
    private float subScoreTimer;
    private float currCardScore;

    private void Awake()
    {
        spRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        inputManager = FindFirstObjectByType<InputManager>();
        cardProvider = FindFirstObjectByType<CardProvider>();
    }

    private void Start()
    {
        currentCard = cardProvider.GetRandomCard();
        spRenderer.sprite = currentCard.sprite;
        originPos = transform.position;
        isSwipeDone = true;
        resultHint.color = Color.gray;
        currCardScore = initCardScore;
    }

    private void Update()
    {
        if (isSwipeDone)
        {
            HandleSwipe();
        }

        cardScoreText.text = "Card Score: " + currCardScore.ToString();
        subScoreTimer += Time.deltaTime;
        if (subScoreTimer >= subScoreTime)
        {
            currCardScore -= 100f;
            subScoreTimer = 0f;
		}

        if (currCardScore > 0)
        {
            cardScoreText.color = Color.green;
		}
        else
        { 
            cardScoreText.color = Color.red;
		}


        /*
        // Dragging using mouse, currently not using this
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject == boxCollider)
            {
                offset = transform.position - mousePosition;
                isDragging = true;
            }
        }
        if (isDragging)
        {
            transform.position = mousePosition + offset;
            Debug.Log("offset: " + offset);
        }
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            transform.position = originPos;
        }
        */
    }

    private void HandleSwipe()
    {
        if (inputManager.swipeUpAction.WasPressedThisFrame())
        {
            Debug.Log("Press Swipe Up");
            StartCoroutine(SwipeUpRoutine());
            CheckAnswer(CardType.Surprise);
        }
        else if (inputManager.swipeDownAction.WasPressedThisFrame())
        {
            StartCoroutine(SwipeDownRoutine());
            CheckAnswer(CardType.Sad);
        }
        else if (inputManager.swipeLeftAction.WasPressedThisFrame())
        {
            StartCoroutine(SwipeLeftRoutine());
            CheckAnswer(CardType.Angry);
        }
        else if (inputManager.swipeRightAction.WasPressedThisFrame())
        {
            StartCoroutine(SwipeRightRoutine());
            CheckAnswer(CardType.Happy);
        }
    }

    private void CheckAnswer(CardType aType)
    {
        if (currentCard.type != aType)
        {
            currCardScore -= 1500f;
        }
        scoreManager.AddScore(currCardScore);
        currCardScore = initCardScore;
        //cardScoreText.transform.DOMoveY(cardScoreText.transform.position.y + 2f, 0.5f);
        StartCoroutine(ResultHintRoutine(aType));
    }

    IEnumerator ResultHintRoutine(CardType aType)
    {
        if (currentCard.type == aType)
        {
            Debug.Log("Correct");
            resultHint.color = Color.green;
        }
        else
        {
            Debug.Log("Wrong");
            resultHint.color = Color.red;
        }
        yield return new WaitForSeconds(0.5f);
        resultHint.color = Color.gray;
    }

    IEnumerator SwipeUpRoutine()
    {
        isSwipeDone = false;
        float posX = transform.position.x;
        float moveY = 0;
        StartCoroutine(FadeOutRoutine());

        while (moveY < moveDis)
        {
            moveY += moveDelta;
            transform.position = new Vector2(posX, moveY);
            yield return new WaitForSeconds(movePeriod);
        }
        UpdateCurrentCard();
        isSwipeDone = true;
    }

    IEnumerator SwipeDownRoutine()
    {
        isSwipeDone = false;
        float posX = transform.position.x;
        float moveY = 0;
        StartCoroutine(FadeOutRoutine());

        while (moveY > -moveDis)
        {
            moveY -= moveDelta;
            transform.position = new Vector2(posX, moveY);
            yield return new WaitForSeconds(movePeriod);
        }
        UpdateCurrentCard();
        isSwipeDone = true;
    }

    IEnumerator SwipeLeftRoutine()
    {
        isSwipeDone = false;
        float posY = transform.position.y;
        float moveX = 0;
        StartCoroutine(FadeOutRoutine());

        while (moveX > -moveDis)
        {
            moveX -= moveDelta;
            transform.position = new Vector2(moveX, posY);
            yield return new WaitForSeconds(movePeriod);
        }
        UpdateCurrentCard();
        isSwipeDone = true;
    }

    IEnumerator SwipeRightRoutine()
    {
        isSwipeDone = false;
        float posY = transform.position.y;
        float moveX = 0;
        StartCoroutine(FadeOutRoutine());

        while (moveX < moveDis)
        {
            moveX += moveDelta;
            transform.position = new Vector2(moveX, posY);
            yield return new WaitForSeconds(movePeriod);
        }
        UpdateCurrentCard();
        isSwipeDone = true;
    }

    IEnumerator FadeOutRoutine()
    {
        while (spRenderer.color.a >= 0f)
        {
            spRenderer.color = new Color(spRenderer.color.r, spRenderer.color.g, spRenderer.color.b, spRenderer.color.a - fadeDelta);
            yield return new WaitForSeconds(fadePeriod);
        }
    }

    private void UpdateCurrentCard()
    {
        currentCard = cardProvider.GetRandomCard();
        transform.position = Vector2.zero;
        spRenderer.sprite = currentCard.sprite;
        spRenderer.color = new Color(spRenderer.color.r, spRenderer.color.g, spRenderer.color.b, 1f);
    }
}
