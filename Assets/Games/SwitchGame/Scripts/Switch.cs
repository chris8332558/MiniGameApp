using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(SpriteRenderer))]
public class Switch : MonoBehaviour
{
    public KeyCode switchKey;
    [SerializeField] private Sprite switchOnSprite;
    [SerializeField] private Sprite switchOffSprite;
    [SerializeField] private SpriteRenderer blockSprite;
    private BoxCollider2D mCollider;
    private SpriteRenderer mSprite;

    public bool isTurnedOn;

    private void Awake()
    {
        mCollider = GetComponent<BoxCollider2D>();
        mSprite = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        mCollider.enabled = true;
        mSprite.sprite = switchOffSprite;
        blockSprite.color = Color.red;
    }

    private void Update()
    {
        if (Input.GetKeyDown(switchKey))
        {
            mCollider.enabled = !mCollider.enabled;
            if (mCollider.enabled)
            {
                isTurnedOn = false;
                //SFXSource.Instance.PlaySwitchOff();
                mSprite.sprite = switchOffSprite;
                blockSprite.color = Color.red;
            }
            else
            {
                isTurnedOn = true;
                //SFXSource.Instance.PlaySwitchOn();
                mSprite.sprite = switchOnSprite;
                blockSprite.color = Color.green;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Energy>(out Energy anEnergy))
        {
            anEnergy.ReturnToPool();
		}
    }
}
